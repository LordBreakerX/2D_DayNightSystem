namespace LordBreakerX.States
{
    public abstract class BaseState<TStateMachine> where TStateMachine : StateMachine<TStateMachine>
    {
        private TStateMachine _stateMachine;

        public TStateMachine StateMachine { get { return _stateMachine; } }

        public virtual void InitalizeState(TStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public abstract void EnterState();

        public abstract void ExitState();

        public abstract void UpdateState();
    }
}
