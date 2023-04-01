
namespace AnaliticsService
{
    public interface IAnalyticsDataStorage
    {
        string CollectedData { get; set; } 
        string SendingData { get; set; }

    }
}
