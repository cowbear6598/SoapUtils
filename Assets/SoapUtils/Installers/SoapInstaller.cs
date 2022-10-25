using SoapUtils.DatabaseSystem;
using SoapUtils.SoundSystem;
using Zenject;

namespace SoapUtils.Installers
{
    public class SoapInstaller : MonoInstaller<SoapInstaller>
    {
        public override void InstallBindings()
        {
            InstallDatabase();
            InstallSound();
        }

        private void InstallDatabase()
        {
            Container.Bind<GetHandler>().AsSingle();
            Container.Bind<PostHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DatabaseService>().AsSingle();
        }

        private void InstallSound()
        {
            Container.Bind<BGMHandler>().AsSingle();
            Container.Bind<EffectHandler>().AsSingle();
            Container.Bind<LoopHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SoundService>().AsSingle();
        }
    }
}