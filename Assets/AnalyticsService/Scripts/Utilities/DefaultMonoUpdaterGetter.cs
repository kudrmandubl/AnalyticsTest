using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class DefaultMonoUpdaterGetter : IMonoUpdaterGetter
    {
        private const string defaultMonoUpdaterName = "MonoUpdater";

        public IMonoUpdater GetMonoUpdater()
        {
            // лучше использовать какоей-нибудь контейнер
            var result = GameObject.FindAnyObjectByType<MonoUpdater>();
            if(result == null)
            {
                result = CreateMonoUpdater();
            }
            return result;
        }

        private MonoUpdater CreateMonoUpdater()
        {
            var go = new GameObject();
            go.name = defaultMonoUpdaterName;
            return go.AddComponent<MonoUpdater>();             
        }
    }
}
