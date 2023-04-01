using System;

namespace Common
{
    public interface IMonoUpdater 
    {
        void AddUpdateAction(Action<float> onUpdateAction);
        void RemoveUpdateAction(Action<float> onUpdateAction);
    }
}
