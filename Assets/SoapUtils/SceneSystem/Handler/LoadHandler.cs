using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace SoapUtils.SceneSystem.Handler
{
    public class LoadHandler
    {
        [Inject] private readonly StateHandler stateHandler;
        [Inject] private readonly SceneView    view;
        
        public async void LoadScene(SceneType sceneType)
        {
            if (stateHandler.GetState() != SceneState.Complete) return;
            
            // 開始讀取場景
            view.SetAppear(true);

            stateHandler.ChangeState(SceneState.Loading);
            
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            
            await SceneManager.LoadSceneAsync((int)sceneType, LoadSceneMode.Additive);
            
            // 釋放前場景
            stateHandler.ChangeState(SceneState.Unloading);

            if (stateHandler.GetSceneType() != SceneType.Bootstrap)
                await SceneManager.UnloadSceneAsync(stateHandler.GetCurrentScene());

            // 讀取完成
            Scene currentScene = SceneManager.GetSceneAt(1);

            SceneManager.SetActiveScene(currentScene);

            stateHandler.SetCurrentScene(currentScene, sceneType);

            view.SetAppear(false);
        }
    }
}