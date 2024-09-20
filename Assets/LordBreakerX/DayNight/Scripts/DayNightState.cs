using LordBreakerX.States;
using UnityEngine;
using UnityEngine.Events;

namespace LordBreakerX.DayNight
{
    [System.Serializable]
    public class DayNightState : BaseState<DayNightManager>
    {
        [SerializeField]
        [Tooltip("Amount of seconds that state lasts")]
        private float _duration;

        [Header("Events")]
        [Tooltip("Unity event that happens when the state starts")]
        public UnityEvent onStateStarted;

        private bool _isNightState;

        private float _checkTime;

        public float Duration { get { return _duration; } }

        public DayNightState(bool isNightState = false)
        {
            _isNightState = isNightState;
        }

        public override void EnterState()
        {
            onStateStarted.Invoke();

            if (!_isNightState)
            {
                StateMachine.ResetTime();
            }

            _checkTime = StateMachine.TimeInDay + _duration;
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            if (_checkTime <= StateMachine.TimeInDay) 
            {
                if (_isNightState) 
                {
                    StateMachine.QueueNextState(StateMachine.DayTransition);
                }
                else
                {
                    StateMachine.QueueNextState(StateMachine.NightTransition);
                }
            }
        }
    }
}
