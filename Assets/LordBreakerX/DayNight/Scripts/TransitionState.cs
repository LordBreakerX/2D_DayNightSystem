using LordBreakerX.States;
using UnityEngine;
using UnityEngine.Events;

namespace LordBreakerX.DayNight
{
    [System.Serializable]
    public class TransitionState : BaseState<DayNightManager>
    {
        [SerializeField]
        [Tooltip("Amount of seconds the transition lasts")]
        private float _duration;


        [SerializeField]
        [Tooltip("the change in color that happens throughout the transition")]
        private Gradient _transitionGradiant = new Gradient();

        [SerializeField]
        private AnimationCurve _transitonCurve = AnimationCurve.Linear(0, 0, 1, 1);

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onStateStarted;

        private bool _transitionToNight;

        private float _checkTime;
        private float _timeEntered;

        public float Duration { get { return _duration; } }

        public TransitionState(bool transitionToNight = false)
        {
            _transitionToNight = transitionToNight;
        }

        public override void EnterState() 
        {
            _timeEntered = StateMachine.TimeInDay;
            _checkTime = _timeEntered + _duration;
            _onStateStarted.Invoke();
        }

        public override void ExitState() { }

        public override void UpdateState()
        {
            float percentage = (StateMachine.TimeInDay - _timeEntered) / _duration;
            float colorValue = _transitonCurve.Evaluate(percentage);
            StateMachine.LightSource.color = _transitionGradiant.Evaluate(colorValue);

            if (_checkTime <= StateMachine.TimeInDay) 
            {
                if (_transitionToNight) 
                {
                    StateMachine.QueueNextState(StateMachine.NightTime);
                }
                else
                {
                    StateMachine.QueueNextState(StateMachine.DayTime);
                }
            }
        }
    }
}
