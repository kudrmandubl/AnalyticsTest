
namespace AnaliticsService
{
    public interface IAnalyticsDataPacker
    {
        string PackCollectedData(string type, string data, string collectedData);
        string PackDataForSend(string collectedData);
    }
}