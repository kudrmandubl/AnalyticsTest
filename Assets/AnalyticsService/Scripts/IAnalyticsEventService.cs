namespace AnaliticsService
{
    public interface IAnalyticsEventService 
    {
        void TrackEvent(string type, string data);
    }
}
