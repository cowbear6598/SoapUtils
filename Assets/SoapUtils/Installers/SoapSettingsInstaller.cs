using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.Installers
{
    [CreateAssetMenu(menuName = "Soap/SoapSettings")]
    public class SoapSettingsInstaller : ScriptableObjectInstaller<SoapSettingsInstaller>
    {
        [SerializeField] private DatabaseSettings databaseSettings;
        [SerializeField] private SceneSettings    sceneSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(databaseSettings).IfNotBound();

            Container.BindInstance(sceneSettings).IfNotBound();
        }
        
        [Serializable]
        public class DatabaseSettings
        {
            public string[] domains;
            public int      timeout;
        }

        [Serializable]
        public class SceneSettings
        {
            public AssetReference[] sceneAssets;
        }
    }
}