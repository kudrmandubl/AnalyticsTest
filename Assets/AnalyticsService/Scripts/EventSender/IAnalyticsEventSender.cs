

using System;

namespace AnaliticsService
{
    public interface IAnalyticsEventSender
    {
        bool IsSending { get; }
        void Send(string data, Action onSucces, Action onError);
    }
}
