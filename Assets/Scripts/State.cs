namespace SlimeRPG
{
    public abstract class State<T> : IState
    {
        protected T _actor;

        public State(T actor)
        {
            _actor = actor;
        }

        public virtual void StartState()
        {
            
        }

        public abstract void DoState();
    }
}