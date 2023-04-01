using UnityEngine;

namespace AnaliticsService
{
    [CreateAssetMenu(fileName = "AnaliticsServiceConfig", menuName = DefaultConfigPath)]
    public class AnaliticsServiceConfig : ScriptableObject
    {
        public const string DefaultConfigPath = "Configs/AnaliticsServiceConfig";

        [SerializeField] private string _serverUrl;
        [SerializeField] private float _cooldownBeforeSend;

        public string ServerUrl => _serverUrl;
        public float CooldownBeforeSend => _cooldownBeforeSend;

    }
}
