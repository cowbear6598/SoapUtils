using Zenject;

namespace SoapUtils.SceneSystem
{
    internal class SceneService : ISceneService
    {
        [Inject] private readonly LoadHandler loadHandler;

        public void DoLoadScene(int sceneIndex) => loadHandler.LoadScene(sceneIndex);
    }
}