using SoapUtils.SceneSystem.Handler;
using Zenject;

namespace SoapUtils.SceneSystem
{
    public enum SceneType
    {
        Bootstrap = 0,
        Menu      = 1,
        Game      = 2
    }

    public class SceneService : ISceneService
    {
        [Inject] private readonly LoadHandler  loadHandler;

        public void DoLoadScene(SceneType sceneType) => loadHandler.LoadScene(sceneType);
    }
}