using UnityEngine;

namespace SoapUtils.Runtime.Utils
{
    public static class VectorUtils
    {
        public static Vector3 GetCirclePosition(float radius, Vector3 centerPosition, Vector3 targetPosition)
        {
            Vector3 deltaPosition = targetPosition - centerPosition;
            Vector3 newPosition   = deltaPosition;

            // 計算是否超出半徑 
            var distance = Vector3.Distance(centerPosition, targetPosition);

            if (distance > radius)
            {
                deltaPosition *= radius / distance;
                newPosition   =  (centerPosition + deltaPosition) - centerPosition;
            }

            return newPosition;
        }
    }
}