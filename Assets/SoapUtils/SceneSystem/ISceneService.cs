using UnityEngine.AddressableAssets;

namespace SoapUtils.SceneSystem
{
    public interface ISceneService
    {
        void DoLoadScene(AssetReference sceneAsset, bool IsFadeOut = true);
        void DoFadeOut();
    }
}