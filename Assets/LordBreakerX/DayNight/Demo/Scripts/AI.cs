using LordBreakerX.States;
using UnityEngine;

namespace LordBreakerX
{
    public class AI : StateMachine<AI>
    {
        [SerializeField]
        private HomeState homeState;
        [SerializeField]
        private ExploreState exploreState;

        protected override void Awake()
        {
            homeState.InitalizeState(this);
            exploreState.InitalizeState(this);
            _currentState = exploreState;
            base.Awake();
        }

        public void GoHome()
        {
            QueueNextState(homeState);
        }

        public void Explore()
        {
            QueueNextState(exploreState);
        }

    }
}
