using LordBreakerX.States;
using UnityEngine;

namespace LordBreakerX
{
    [System.Serializable]
    public class ExploreState : BaseState<AI>
    {
        [SerializeField]
        private float buffer = 0.2f;

        [SerializeField]
        private float speed = 20;

        [SerializeField]
        private Transform[] _movePoints;

        private Transform _point;

        public override void EnterState()
        {
            UpdatePoint();
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            if (_point == null) return;

            if (Vector3.Distance(StateMachine.transform.position, _point.position) < buffer)
            {
                UpdatePoint();
            }

            StateMachine.transform.position = Vector3.MoveTowards(StateMachine.transform.position, _point.position, speed * Time.deltaTime);
        }

        public void UpdatePoint()
        {
            if (_movePoints.Length > 0)
            {
                int index = Random.Range(0, _movePoints.Length);
                _point = _movePoints[index];
            }
        }
    }
}
