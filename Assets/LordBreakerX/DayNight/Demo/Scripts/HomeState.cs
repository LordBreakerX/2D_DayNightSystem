using LordBreakerX.States;
using UnityEngine;

namespace LordBreakerX
{
    [System.Serializable]
    public class HomeState : BaseState<AI>
    {
        [SerializeField]
        private Transform home;
        [SerializeField]
        private float speed = 20;

        public override void EnterState()
        {
            
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            StateMachine.transform.position = Vector3.MoveTowards(StateMachine.transform.position, home.position, speed * Time.deltaTime);
        }
    }
}
