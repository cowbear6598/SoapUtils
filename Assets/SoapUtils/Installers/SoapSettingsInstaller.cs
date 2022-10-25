using System;
using UnityEngine;
using Zenject;

namespace SoapUtils.Installers
{
    [CreateAssetMenu(menuName = "Soap/SoapSettings")]
    public class SoapSettingsInstaller : ScriptableObjectInstaller<SoapSettingsInstaller>
    {
        [SerializeField] private DatabaseSettings databaseSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(databaseSettings).IfNotBound();
        }
        
        [Serializable]
        public class DatabaseSettings
        {
            public string[] domains;
            public int      timeout;
        }
    }
}