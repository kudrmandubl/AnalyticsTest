using System;
using UnityEngine;

namespace Common
{
    public class MonoUpdater : MonoBehaviour, IMonoUpdater
    {
        private Action<float> _onUpdate;

        public void AddUpdateAction(Action<float> onUpdateAction)
        {
            _onUpdate += onUpdateAction;
        }

        public void RemoveUpdateAction(Action<float> onUpdateAction)
        {
            _onUpdate -= onUpdateAction;
        }

        private void Update()
        {
            Tick();
        }

        private void Tick()
        {
            _onUpdate?.Invoke(Time.deltaTime);
        }
    }
}
