using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace AnaliticsService
{
    public class AnalyticsEventSender : IAnalyticsEventSender
    {

        private string _serverUrl;
        private bool _isSending;

        private Action _onSucces;
        private Action _onError;

        public bool IsSending => _isSending;

        public AnalyticsEventSender(string serverUrl)
        {
            _serverUrl = serverUrl;
        }

        public void Send(string data, Action onSucces, Action onError)
        {
            _onSucces = onSucces;
            _onError = onError;
            try
            {
                UnityWebRequest request = new UnityWebRequest(_serverUrl, "POST");

                request.SetRequestHeader("Content-Type", "application/json");

                byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);

                request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

                UnityWebRequestAsyncOperation requestOperation = request.SendWebRequest();
                requestOperation.completed += (_) => Complete(requestOperation);

                Debug.Log("Request Success Called");
                _isSending = true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Error {e}: {e.Message}");
                _onError?.Invoke();
            }
        }

        private void Complete(UnityWebRequestAsyncOperation requestOperation)
        {
            _isSending = false;

            UnityWebRequest request = requestOperation.webRequest;
            if (request.responseCode != 200)
            {
                Debug.LogError($"Error: {requestOperation.webRequest.error}");
                _onError?.Invoke();
                return;
            }

            Debug.Log("Success " + request.downloadHandler.text);
            _onSucces?.Invoke();
        }
    }
}
