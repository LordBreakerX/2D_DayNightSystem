using LordBreakerX.States;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace LordBreakerX.DayNight
{
    [RequireComponent(typeof(Light2D))]
    public class DayNightManager : StateMachine<DayNightManager>
    {
        [SerializeField]
        private bool _startAsDay = true;

        [SerializeField]
        private DayNightState _dayTime = new DayNightState();

        [SerializeField]
        private DayNightState _nightTime = new DayNightState(true);

        [SerializeField]
        private TransitionState _dayTransition = new TransitionState();

        [SerializeField]
        private TransitionState _nightTransition = new TransitionState(true);

        private Light2D _lightSource;

        public DayNightState DayTime {  get { return _dayTime; } }

        public DayNightState NightTime { get { return _nightTime; } }

        public TransitionState NightTransition { get { return _nightTransition; } }
        public TransitionState DayTransition { get { return _dayTransition; } }

        public Light2D LightSource { get { return _lightSource; } }

        public float TimeInDay { get; private set; }

        public float DayLength {  get; private set; }

        protected override void Awake()
        {
            _dayTime.InitalizeState(this);
            _nightTime.InitalizeState(this);
            _dayTransition.InitalizeState(this);
            _nightTransition.InitalizeState(this);

            DayLength = _dayTime.Duration + _nightTime.Duration + _dayTransition.Duration + _nightTransition.Duration;

            _lightSource = GetComponent<Light2D>();

            if (_startAsDay) _currentState = _dayTime;
            else _currentState = _nightTime;

            base.Awake();
        }

        private void FixedUpdate()
        {
            TimeInDay += Time.fixedDeltaTime;
        }

        public void ResetTime()
        {
            TimeInDay = 0;
        }

    }
}
