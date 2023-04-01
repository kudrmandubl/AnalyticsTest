using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class Timer : ITimer
    {
        private IMonoUpdater _monoUpdater;
        private float _duration;
        private bool _isActive;

        private Action _onComplete;

        public bool IsActive => _isActive;

        public Timer()
        {
            GetMonoUpdater(out _monoUpdater);
        }

        public void Wait(float duration, Action onComplete)
        {
            _duration = duration;
            _onComplete = onComplete;
            _monoUpdater.AddUpdateAction(TimerTick);
            _isActive = true;
        }

        private void GetMonoUpdater(out IMonoUpdater monoUpdater)
        {
            IMonoUpdaterGetter getter = new DefaultMonoUpdaterGetter();
            monoUpdater = getter.GetMonoUpdater();
        }

        private void TimerTick(float deltaTime)
        {
            _duration -= deltaTime;
            if (_duration <= 0)
            {
                CompleteTimer();
            }
        }

        private void CompleteTimer()
        {
            _monoUpdater.RemoveUpdateAction(TimerTick);
            _onComplete?.Invoke();
            _isActive = false;
        }

    }
}
