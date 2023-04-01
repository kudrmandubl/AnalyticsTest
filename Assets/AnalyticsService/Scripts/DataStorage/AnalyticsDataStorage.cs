
using UnityEngine;

namespace AnaliticsService
{
    /// <summary>
    /// Сохраняет в префсы - точно сработает и на Android и на WebGL
    /// </summary>
    public class AnalyticsDataStorage : IAnalyticsDataStorage
    {
        private const string collectedDataKey = "AnalyticsDataStorage.collectedDataKey";
        private const string sendingDataKey = "AnalyticsDataStorage.sendingDataKey";

        private string _collectedData;
        private string _sendingData;

        public string CollectedData 
        {
            get { return _collectedData; }
            set
            {
                _collectedData = value;
                PlayerPrefs.SetString(collectedDataKey, value);
                PlayerPrefs.Save();
            }
        }
        public string SendingData
        {
            get { return _sendingData; }
            set 
            {
                _sendingData = value;
                PlayerPrefs.SetString(sendingDataKey, value);
                PlayerPrefs.Save();
            }
        }

        public AnalyticsDataStorage()
        {
            LoadData();
        }

        private void LoadData()
        {
            _collectedData = PlayerPrefs.GetString(collectedDataKey, "");
            _sendingData = PlayerPrefs.GetString(sendingDataKey, "");
        }


    }
}
