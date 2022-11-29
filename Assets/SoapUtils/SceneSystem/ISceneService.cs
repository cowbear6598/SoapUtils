using UnityEngine.AddressableAssets;

namespace SoapUtils.SceneSystem
{
    public interface ISceneService
    {
        void DoLoadScene(int sceneIndex, bool IsFadeOut = true);
        void DoFadeOut();
    }
}