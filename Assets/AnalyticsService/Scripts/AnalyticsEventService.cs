using Common;using UnityEngine;

namespace AnaliticsService
{
    public class AnalyticsEventService : IAnalyticsEventService
    {
        private IAnalyticsEventSender _eventSender;
        private IAnalyticsDataPacker _dataPacker;
        private IAnalyticsDataStorage _dataStorage;
        private ITimer _cooldownTimer;
        private float _cooldownBeforeSend;
        
        public AnalyticsEventService() 
        {
            IConfigGetter configGetter = new DefaultConfigGetter();
            AnaliticsServiceConfig config = configGetter.GetConfig();
            if (!config)
            {
                Debug.LogError("Can't Create AnalyticsEventService because AnaliticsServiceConfig is NULL");
                return;
            }

            _eventSender = new AnalyticsEventSender(config.ServerUrl);
            _dataPacker = new AnalyticsDataPacker();
            _dataStorage = new AnalyticsDataStorage();
            _cooldownTimer = new Timer();
            _cooldownBeforeSend = config.CooldownBeforeSend;
            TryResendPrevSessionData();
        }

        public void TrackEvent(string type, string data)
        {
            Debug.Log($"TrackEvent type = {type} data = {data}");
            _dataStorage.CollectedData = _dataPacker.PackCollectedData(type, data, _dataStorage.CollectedData);
            TrySend();
        }


        private void TryResendPrevSessionData()
        {
            if (string.IsNullOrEmpty(_dataStorage.SendingData))
            {
                return;
            }
            Resend();
        }


        private void TrySend()
        {
            if (_cooldownTimer.IsActive || _eventSender.IsSending)
            {
                return;
            }
            _cooldownTimer.Wait(_cooldownBeforeSend, Send);
        }

        private void Send()
        {
            _dataStorage.SendingData = _dataStorage.CollectedData;
            _dataStorage.CollectedData = "";
            _eventSender.Send(_dataPacker.PackDataForSend(_dataStorage.SendingData), SuccesSending, ErrorSending);
        }

        private void SuccesSending()
        {
            _dataStorage.SendingData = "";
            if (!string.IsNullOrEmpty(_dataStorage.CollectedData))
            {
                TrySend();
            }
        }

        private void ErrorSending()
        {
            Resend();
        }


        private void Resend()
        {
            _dataStorage.CollectedData = SetDataBack(_dataStorage.CollectedData, _dataStorage.SendingData);
            TrySend();
        }

        private string SetDataBack(string collectedData, string sendingData)
        {
            collectedData = sendingData + (string.IsNullOrEmpty(collectedData) ? "" : "," + collectedData);
            return collectedData;
        }
    }
}