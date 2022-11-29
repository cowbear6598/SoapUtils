using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.SceneSystem
{
    internal class SceneService : ISceneService
    {
        [Inject] private readonly LoadHandler loadHandler;

        public void DoLoadScene(int sceneIndex, bool IsFadeOut = true) => loadHandler.LoadScene(sceneIndex, IsFadeOut);
        public void DoFadeOut() => loadHandler.FadeOut();
    }
}