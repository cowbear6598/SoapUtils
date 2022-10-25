using UnityEngine.SceneManagement;

namespace SoapUtils.SceneSystem
{
    public enum SceneState
    {
        Complete  = 0,
        Loading   = 1,
        Unloading = 2
    }

    internal class StateHandler
    {
        private int   currentSceneIndex = 0;
        private Scene currentScene;

        private SceneState state = SceneState.Complete;
        public SceneState GetState() => state;

        public void ChangeState(SceneState state) => this.state = state;

        public int GetSceneIndex() => currentSceneIndex;
        public Scene GetCurrentScene() => currentScene;

        public void SetCurrentScene(Scene currentScene, int sceneIndex)
        {
            this.currentScene = currentScene;
            currentSceneIndex = sceneIndex;

            ChangeState(SceneState.Complete);
        }
    }
}