using SoapUtils.DatabaseSystem;
using SoapUtils.NotifySystem;
using SoapUtils.PrefsSystem;
using SoapUtils.SceneSystem;
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
            InstallScene();
            InstallPrefs();
            InstallNotify();
        }

        private void InstallNotify()
        {
            Container.Bind<NotifyView>().FromComponentInHierarchy().AsSingle();
            
            Container.BindInterfacesAndSelfTo<NotifyService>().AsSingle();
        }

        private void InstallPrefs()
        {
            Container.BindInterfacesAndSelfTo<PrefsService>().AsSingle();
        }

        private void InstallScene()
        {
            Container.Bind<SceneView>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<LoadHandler>().AsSingle();
            Container.Bind<StateHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneService>().AsSingle();
        }

        private void InstallDatabase()
        {
            Container.Bind<GetHandler>().AsSingle();
            Container.Bind<PostHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DatabaseService>().AsSingle();
        }

        private void InstallSound()
        {
            Container.Bind<SoundView>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<BGMHandler>().AsSingle();
            Container.Bind<EffectHandler>().AsSingle();
            Container.Bind<LoopHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SoundService>().AsSingle();
        }
    }
}