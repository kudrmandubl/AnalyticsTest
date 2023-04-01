
namespace AnaliticsService
{
    public class AnalyticsDataPacker : IAnalyticsDataPacker
    {
        private const string mainSendFormat = "\"events\":[{0}]";
        private const string itemSendFormat = "\"type\":\"{0}\",\"data\":\"{1}\"";

        public string PackCollectedData(string type, string data, string collectedData)
        {
            collectedData += $"{(string.IsNullOrEmpty(collectedData) ? "" : ",")}{{{string.Format(itemSendFormat, type, data)}}}";
            return collectedData;
        }

        public string PackDataForSend(string collectedData)
        {
            return $"{{{string.Format(mainSendFormat, collectedData)}}}";
        }
    }
}
