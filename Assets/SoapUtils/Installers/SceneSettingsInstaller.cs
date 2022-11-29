using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.Installers
{
    [CreateAssetMenu(menuName = "Soap/SceneSettings")]
    public class SceneSettingsInstaller : ScriptableObjectInstaller<SceneSettingsInstaller>
    {
        [SerializeField] private Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings).IfNotBound();
        }

        [Serializable]
        public class Settings
        {
            public AssetReference[] sceneAssets;
        }
    }
}