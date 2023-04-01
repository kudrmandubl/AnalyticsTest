using AnaliticsService;
using Common;
using UnityEngine;

public class Sample 
{

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        IAnalyticsEventService analyticsEventService = new AnalyticsEventService();
        analyticsEventService.TrackEvent("levelStart", "level:3");
        analyticsEventService.TrackEvent("addReward", "soft:10");
       
        ITimer timer = new Timer();
        timer.Wait(2, () => analyticsEventService.TrackEvent("spendSoft", "value:2"));
        timer = new Timer();
        timer.Wait(5, () => analyticsEventService.TrackEvent("spendSoft", "value:5"));
        timer = new Timer();
        timer.Wait(9, () => analyticsEventService.TrackEvent("spendSoft", "value:9"));
    }

}
