using UnityEngine;

namespace AnaliticsService
{
    public class DefaultConfigGetter : IConfigGetter
    {
        public AnaliticsServiceConfig GetConfig()
        {
            return Resources.Load<AnaliticsServiceConfig>(AnaliticsServiceConfig.DefaultConfigPath);
        }
    }
}
