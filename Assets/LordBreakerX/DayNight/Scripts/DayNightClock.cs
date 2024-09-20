using UnityEngine;

namespace LordBreakerX.DayNight
{
    public class DayNightClock : MonoBehaviour
    {
        [SerializeField]
        private DayNightManager manager;

        [SerializeField]
        private RectTransform _clockRotate;

        [SerializeField]
        private float _angleOffset;

        private void Update()
        {
            if (_clockRotate != null)
            {
                float percentage = manager.TimeInDay / manager.DayLength;
                float rotation = (360 * percentage) + _angleOffset;

                if (rotation > 360)
                {
                    rotation -= 360;
                }

                _clockRotate.rotation = Quaternion.Euler(0, 0, rotation);
            }

        }
    }
}

