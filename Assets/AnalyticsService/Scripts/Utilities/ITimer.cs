using System;

namespace Common
{
    public interface ITimer 
    {
        bool IsActive { get; }
        void Wait(float duration, Action onComplete);
    }
}
