using UnityEngine.SceneManagement;

namespace SoapUtils.Runtime.SceneSystem
{
    public class SceneStateHandler
    {
        public enum SceneType
        {
            Bootstrap = 0,
            Menu      = 1,
            Game      = 2
        }
        private SceneType currentSceneType = SceneType.Bootstrap;
        private Scene     currentScene;

        public enum SceneState
        {
            Complete  = 0,
            Loading   = 1,
            Unloading = 2
        }
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