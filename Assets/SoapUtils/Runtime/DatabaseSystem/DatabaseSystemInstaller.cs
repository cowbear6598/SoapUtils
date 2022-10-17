using UnityEngine;
using Zenject;

namespace SoapUtils.Runtime.DatabaseSystem
{
    [CreateAssetMenu(menuName = "Soap/DatabaseSettings")]
    public class DatabaseSystemInstaller : ScriptableObjectInstaller<DatabaseSystemInstaller>
    {
        public DatabaseSystem.Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings).IfNotBound();
        }
    }
}