using UnityEngine;
using Zenject;

namespace SoapUtils.Runtime.DatabaseSystem
{
    [CreateAssetMenu(menuName = "Soap/DatabaseSettings")]
    public class DatabaseServiceInstaller : ScriptableObjectInstaller<DatabaseServiceInstaller>
    {
        public DatabaseService.Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings).IfNotBound();
        }
    }
}