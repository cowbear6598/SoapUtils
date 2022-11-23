using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.SceneSystem
{
    internal class SceneService : ISceneService
    {
        [Inject] private readonly LoadHandler loadHandler;

        public void DoLoadScene(AssetReference sceneAsset, bool IsFadeOut = true) => loadHandler.LoadScene(sceneAsset, IsFadeOut);
        public void DoFadeOut() => loadHandler.FadeOut();
    }
}