using UnityEngine.SceneManagement;

namespace SoapUtils.SceneSystem.Handler
{
    public enum SceneState
    {
        Complete  = 0,
        Loading   = 1,
        Unloading = 2
    }
    
    public class StateHandler
    {
        private SceneType currentSceneType = SceneType.Bootstrap;
        private Scene     currentScene;
        
        private SceneState state = SceneState.Complete;

        public SceneState GetState() => state;
        public void ChangeState(SceneState state)
        {
            this.state = state;
        }

        public SceneType GetSceneType() => currentSceneType;
        public Scene GetCurrentScene() => currentScene;
        
        public void SetCurrentScene(Scene currentScene, SceneType sceneType)
        {
            this.currentScene = currentScene;
            currentSceneType  = sceneType;
            
            ChangeState(SceneState.Complete);
        }
    }
}