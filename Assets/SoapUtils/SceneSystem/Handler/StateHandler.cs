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
        private SceneState state = SceneState.Complete;
        public SceneState GetState() => state;

        public void ChangeState(SceneState state) => this.state = state;
    }
}