using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace SoapUtils.Runtime.SceneSystem
{
    public class SceneService : ISceneService
    {
        [Inject] private readonly SceneView         sceneView;
        [Inject] private readonly SceneStateHandler stateHandler;

        public async void LoadScene(SceneStateHandler.SceneType sceneType)
        {
            if (stateHandler.GetState() != SceneStateHandler.SceneState.Complete) return;

            // 開始讀取場景
            sceneView.SetAppear(true);

            stateHandler.ChangeState(SceneStateHandler.SceneState.Loading);

            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

            await SceneManager.LoadSceneAsync((int)sceneType, LoadSceneMode.Additive);

            // 釋放前場景
            stateHandler.ChangeState(SceneStateHandler.SceneState.Unloading);

            if (stateHandler.GetSceneType() != SceneStateHandler.SceneType.Bootstrap)
                await SceneManager.UnloadSceneAsync(stateHandler.GetCurrentScene());

            // 讀取完成
            Scene currentScene = SceneManager.GetSceneAt(1);

            SceneManager.SetActiveScene(currentScene);

            stateHandler.SetCurrentScene(currentScene, sceneType);

            sceneView.SetAppear(false);
        }
    }
}