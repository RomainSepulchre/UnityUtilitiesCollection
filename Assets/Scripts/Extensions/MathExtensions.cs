using UnityEngine;

namespace RS.Extensions
{
	public static class MathExtensions
	{
        #region Transform and Vector

        // Squared magnitude

        /// <summary>
        /// Calculate the squared magnitude between this transform position and <i>'target'</i> Vector3
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Position we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude between this transform position and <i>'target'</i> Vector3</returns>
        public static float SqrMagnitudeWith(this Transform tf, Vector3 target)
        {
            return tf.position.SqrMagnitudeWith(target);
        }

        /// <summary>
        /// Calculate the squared magnitude between this Vector3 and <i>'to'</i> Vector3
        /// </summary>
        /// <param name="from">Vector3 that calls the extension method</param>
        /// <param name="to">Position we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude between this Vector3 and <i>'to'</i> vector3</returns>
        public static float SqrMagnitudeWith(this Vector3 from, Vector3 to)
        {
            return (from - to).sqrMagnitude;
        }

        // Squared magnitude/magnitude on X and Z axis

        /// <summary>
        /// Calculate the squared magnitude on X and Z axis between this transform position and <i>'target'</i> Vector3
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Position we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude on X and Z axis between this transform position and <i>'target'</i> Vector3</returns>
        public static float XzSqrMagnitudeWith(this Transform tf, Vector3 target)
        {
            return tf.position.XzSqrMagnitudeWith(target);
        }

        /// <summary>
        /// Calculate the squared magnitude on X and Z axis between this Vector3 and <i>'to'</i> Vector3
        /// </summary>
        /// <param name="from">Vector3 that calls the extension method</param>
        /// <param name="to">Position we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude on X and Z axis between this Vector3 and <i>'to'</i> vector3</returns>
        public static float XzSqrMagnitudeWith(this Vector3 from, Vector3 to)
        {
            return (from - to).XzSqrMagnitude();
        }

        /// <summary>
        /// Calculate the squared magnitude of this Vector3 on X and Z axis
        /// </summary>
        /// <param name="v">Vector3 that calls the extension method</param>
        /// <returns>Squared magnitude on X and Z axis for this Vector3</returns>
        public static float XzSqrMagnitude(this Vector3 v)
        {
            return v.x * v.x + v.z * v.z;
        }

        /// <summary>
        /// Calculate the magnitude of this vector on X and Z axis
        /// </summary>
        /// <param name="v">Vector3 that calls the extension method</param>
        /// <returns>Magnitude on X and Z axis for this Vector3</returns>
        public static float XzMagnitude(this Vector3 v)
        {
            return Mathf.Sqrt(v.XzSqrMagnitude());
        }

        // Squared magnitude/magnitude on X and Y axis

        /// <summary>
        /// Calculate the squared magnitude on X and Y axis between this transform position and <i>'target'</i> Vector3
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Position we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude on X and Y axis between this transform position and <i>'target'</i> Vector3</returns>
        public static float XySqrMagnitudeWith(this Transform tf, Vector3 target)
        {
            return tf.position.XySqrMagnitudeWith(target);
        }

        /// <summary>
        /// Calculate the squared magnitude on X and Y axis between this Vector3 and <i>'to'</i> Vector3
        /// </summary>
        /// <param name="from">Vector3 that calls the extension method</param>
        /// <param name="to">Position we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude on X and Y axis between this Vector3 and <i>'to'</i> vector3</returns>
        public static float XySqrMagnitudeWith(this Vector3 from, Vector3 to)
        {
            return (from - to).XySqrMagnitude();
        }

        /// <summary>
        /// Calculate the squared magnitude of this Vector3 on X and Y axis
        /// </summary>
        /// <param name="v">Vector3 that calls the extension method</param>
        /// <returns>Squared magnitude on X and Y axis for this Vector3</returns>
        public static float XySqrMagnitude(this Vector3 v)
        {
            return v.x * v.x + v.y * v.y;
        }

        /// <summary>
        /// Calculate the magnitude of this vector on X and Y axis
        /// </summary>
        /// <param name="v">Vector3 that calls the extension method</param>
        /// <returns>Magnitude on X and Y axis for this Vector3</returns>
        public static float XyMagnitude(this Vector3 v)
        {
            return Mathf.Sqrt(v.XySqrMagnitude());
        }

        // Squared magnitude/magnitude on Y and Z axis

        /// <summary>
        /// Calculate the squared magnitude on Y and Z axis between this transform position and <i>'target'</i> Vector3
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Position we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude on Y and Z axis between this transform position and <i>'target'</i> Vector3</returns>
        public static float YzSqrMagnitudeWith(this Transform tf, Vector3 target)
        {
            return tf.position.YzSqrMagnitudeWith(target);
        }

        /// <summary>
        /// Calculate the squared magnitude on Y and Z axis between this Vector3 and <i>'to'</i> Vector3
        /// </summary>
        /// <param name="from">Vector3 that calls the extension method</param>
        /// <param name="to">Position we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude on Y and Z axis between this Vector3 and <i>'to'</i> vector3</returns>
        public static float YzSqrMagnitudeWith(this Vector3 from, Vector3 to)
        {
            return (from - to).YzSqrMagnitude();
        }

        /// <summary>
        /// Calculate the squared magnitude of this Vector3 on Y and Z axis
        /// </summary>
        /// <param name="v">Vector3 that calls the extension method</param>
        /// <returns>Squared magnitude on Y and Z axis for this Vector3</returns>
        public static float YzSqrMagnitude(this Vector3 v)
        {
            return v.y * v.y + v.z * v.z;
        }

        /// <summary>
        /// Calculate the magnitude of this vector on Y and Z axis
        /// </summary>
        /// <param name="v">Vector3 that calls the extension method</param>
        /// <returns>Magnitude on Y and Z axis for this Vector3</returns>
        public static float YzMagnitude(this Vector3 v)
        {
            return Mathf.Sqrt(v.XySqrMagnitude());
        }

        // Local scale

        /// <summary>
        /// Set this transform local scale X value
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="value">New X value for the local scale</param>
        public static void SetLocalScaleX(this Transform tf, float value)
        {
            Vector3 scale = tf.localScale;
            scale.x = value;
            tf.localScale = scale;
        }

        /// <summary>
        /// Set this transform local scale Y value
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="value">New Y value for the local scale</param>
        public static void SetLocalScaleY(this Transform tf, float value)
        {
            Vector3 scale = tf.localScale;
            scale.y = value;
            tf.localScale = scale;
        }

        /// <summary>
        /// Set this transform local scale Z value
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="value">New Z value for the local scale</param>
        public static void SetLocalScaleZ(this Transform tf, float value)
        {
            Vector3 scale = tf.localScale;
            scale.z = value;
            tf.localScale = scale;
        }
        #endregion
    }
}
