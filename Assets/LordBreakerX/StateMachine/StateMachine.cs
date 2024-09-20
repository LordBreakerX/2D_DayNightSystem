using UnityEngine;

namespace LordBreakerX.States
{
    public abstract class StateMachine<TStateMachine> : MonoBehaviour where TStateMachine : StateMachine<TStateMachine>
    {
        protected BaseState<TStateMachine> _currentState;

        private bool _isTransitioningState;

        private BaseState<TStateMachine> _queuedState;

        public BaseState<TStateMachine> CurrentState { get => _currentState; }

        protected virtual void Awake()
        {
            _currentState.EnterState();
        }

        protected virtual void Update()
        {

            if (!_isTransitioningState && (_queuedState == null || _queuedState == _currentState))
            {
                _currentState.UpdateState();
            }
            else if (_queuedState != null && _queuedState != _currentState)
            {
                TransitionToState();
            }

        }

        public void QueueNextState(BaseState<TStateMachine> nextState)
        {
            _queuedState = nextState;
        }

        private void TransitionToState()
        {
            _isTransitioningState = true;
            _currentState.ExitState();
            _currentState = _queuedState;
            _currentState.EnterState();
            _isTransitioningState = false;
        }
    }
}
