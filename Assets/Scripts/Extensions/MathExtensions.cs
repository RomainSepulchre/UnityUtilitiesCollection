using UnityEngine;

namespace RS.Extensions
{
	public static class MathExtensions
	{
        public const float ONE_RADIAN_IN_DEGREE = 57.2958f;

        #region Transform and Vector

        // Squared magnitude

        /// <summary>
        /// Calculate the squared magnitude between this transform position and <i>'target'</i> Transform position
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Transform we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude between this transform position and <i>'target'</i> Transform position</returns>
        public static float SqrMagnitudeWith(this Transform tf, Transform target)
        {
            return tf.position.SqrMagnitudeWith(target.position);
        }

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
        /// Calculate the squared magnitude on X and Z axis between this transform position and <i>'target'</i> Transform position
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Transform we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude on X and Z axis between this transform position and <i>'target'</i> Transform position</returns>
        public static float XzSqrMagnitudeWith(this Transform tf, Transform target)
        {
            return tf.position.XzSqrMagnitudeWith(target.position);
        }

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
        /// Calculate the squared magnitude on X and Y axis between this transform position and <i>'target'</i> Transform position
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Transform we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude on X and Y axis between this transform position and <i>'target'</i> Transform position</returns>
        public static float XySqrMagnitudeWith(this Transform tf, Transform target)
        {
            return tf.position.XySqrMagnitudeWith(target.position);
        }

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
        /// Calculate the squared magnitude on Y and Z axis between this transform position and <i>'target'</i> Transform position
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Transform we want to calculate squared magnitude with</param>
        /// <returns>Squared magnitude on Y and Z axis between this transform position and <i>'target'</i> Transform position</returns>
        public static float YzSqrMagnitudeWith(this Transform tf, Transform target)
        {
            return tf.position.YzSqrMagnitudeWith(target.position);
        }

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
            return Mathf.Sqrt(v.YzSqrMagnitude());
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

        #region Angle and Rotation

        // TODO: Add other axis (enum param in method) ?

        /// <summary>
        /// Progressively rotate this transform toward <i>'target'</i> Transform position in Y axis at a max of <i>'rate'</i> percent (0 to 1.0)
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Transform to look at</param>
        /// <param name="rate">Percent of the angle to turn (0 to 1.0)</param>
        public static void RotateTowardPercent(this Transform tf, Transform target, float rate)
        {
            tf.RotateTowardPercent(target.position, rate);
        }

        /// <summary>
        /// Progressively rotate this transform toward <i>'target'</i> Vector3 in Y axis at a max of <i>'rate'</i> percent (0 to 1.0)
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Position to look at</param>
        /// <param name="rate">Percent of the angle to turn (0 to 1.0)</param>
        public static void RotateTowardPercent(this Transform tf, Vector3 target, float rate)
        {
            Vector3 toTargetVector = target - tf.position;
            toTargetVector.y = 0f;
            float dist = toTargetVector.magnitude;

            if (dist <= 0.001f) return;

            toTargetVector /= dist;

            float currentAngle = Mathf.Acos(Mathf.Clamp(Vector3.Dot(tf.forward, toTargetVector), -1, 1)) * ONE_RADIAN_IN_DEGREE;

            //Right hand rule to check if the direction is to the right or to the left;
            float crossY = Vector3.Cross(tf.forward, toTargetVector).y > 0 ? 1f : -1f;
            float rotationAngle = currentAngle * rate;

            tf.Rotate(Vector3.up * crossY, rotationAngle);
        }

        /// <summary>
        /// Progressively rotate this transform toward <i>'target'</i> Transform position in Y axis at a max of <i>'rate'</i> degree (0 to 180)
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Transform to look at</param>
        /// <param name="rate">Max angular movement in degrees per seconds (0 to 180)</param>
        public static void RotateToward(this Transform tf, Transform target, float rate)
        {
            tf.RotateToward(target.position, rate);
        }

        /// <summary>
        /// Progressively rotate this transform toward <i>'target'</i> Vector3 in Y axis at a max of <i>'rate'</i> degree (0 to 180)
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Position to look at</param>
        /// <param name="rate">Max angular movement in degrees per seconds (0 to 180)</param>
        public static void RotateToward(this Transform tf, Vector3 target, float rate)
        {
            Vector3 toTargetVector = target - tf.position;
            toTargetVector.y = 0f;
            float dist = toTargetVector.magnitude;

            if (dist <= 0.001f) return;

            toTargetVector /= dist;

            float currentAngle = Mathf.Acos(Mathf.Clamp(Vector3.Dot(tf.forward, toTargetVector), -1, 1)) * ONE_RADIAN_IN_DEGREE;

            //Right hand rule to check if the direction is to the right or to the left;
            float crossY = Vector3.Cross(tf.forward, toTargetVector).y > 0 ? 1f : -1f;

            if (currentAngle > rate) tf.Rotate(Vector3.up * crossY, rate);
            else tf.Rotate(Vector3.up * crossY, currentAngle);
        }

        /// <summary>
        /// Instantly rotate this transform toward <i>'target'</i> Transform position in Y axis only
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Transform to look at</param>
        public static void RotateToward(this Transform tf, Transform target)
        {
            tf.RotateToward(target.position);
        }

        /// <summary>
        /// Instantly rotate this transform toward <i>'target'</i> in Y axis only
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Position to look at</param>
        public static void RotateToward(this Transform tf, Vector3 target)
        {
            tf.RotateToward(target, 180f);
        }

        /// <summary>
        /// Calcute the angle between this transform forward and the direction of <i>'target'</i> Transform position in Y axis
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Transform we want to calculate the angle with</param>
        /// <returns>Angle between this transform position and <i>'target'</i> Transform position in degree</returns>
        public static float AngleWith(this Transform tf, Transform target)
        {
            return tf.AngleWith(target.position);
        }

        /// <summary>
        /// Calcute the angle between this transform forward and the direction of <i>'target'</i> Vector3 in Y axis
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="target">Position we want to calculate the angle with</param>
        /// <returns>Angle between this transform position and <i>'target'</i> Vector3 in degree</returns>
        public static float AngleWith(this Transform tf, Vector3 target)
        {
            Vector3 toTargetVector = target - tf.position;
            toTargetVector.y = 0f;
            toTargetVector = toTargetVector.normalized;

            float currentAngle = Mathf.Acos(Mathf.Clamp(Vector3.Dot(tf.forward, toTargetVector), -1, 1)) * ONE_RADIAN_IN_DEGREE;

            //Right hand rule to check if the direction is to the right or to the left;
            float crossY = Vector3.Cross(tf.forward, toTargetVector).y > 0 ? 1f : -1f;
            return currentAngle * (crossY > 0 ? 1 : -1);
        }    

        /// <summary>
        /// Calculate the angle between 2 Vector3: this Vector3 and another Vector3 in Y axis
        /// </summary>
        /// <param name="forward">Vector3 that calls the extension method, we consider it as a forward vector</param>
        /// <param name="vector">Position we want to calculate the angle with</param>
        /// <returns>Angle between this Vector3 and another Vector3 in the Y axis in degree</returns>
        public static float AngleWith(this Vector3 forward, Vector3 vector)
        {
            forward = forward.normalized;
            vector = vector.normalized;

            float currentAngle = Mathf.Acos(Mathf.Clamp(Vector3.Dot(forward, vector), -1, 1)) * ONE_RADIAN_IN_DEGREE;

            //Right hand rule to check if the direction is to the right or to the left;
            float crossY = Vector3.Cross(forward, vector).y > 0 ? 1f : -1f;
            currentAngle *= (crossY > 0 ? 1 : -1);
            while (currentAngle > 180) currentAngle -= 360f;
            while (currentAngle < -180) currentAngle += 360f;

            return currentAngle;
        }

        /// <summary>
        /// Calculate this Vector3 angle from Vector3.Forward in Y axis
        /// </summary>
        /// <param name="v">Vector3 that calls the extension method</param>
        /// <returns>Angle between this Vector3 and Vector3.Forward in the Y axis in degree</returns>
        public static float Angle(this Vector3 v)
        {
            v = v.normalized;

            float currentAngle = Mathf.Acos(Mathf.Clamp(Vector3.Dot(Vector3.forward, v), -1, 1)) * ONE_RADIAN_IN_DEGREE;

            //Right hand rule to check if the direction is to the right or to the left;
            float crossY = Vector3.Cross(Vector3.forward, v).y > 0 ? 1f : -1f;
            return currentAngle * (crossY > 0 ? 1 : -1);
        }

        /// <summary>
        /// Set the local X axis rotation (in degree)
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="value">New X axis rotation value in degree</param>
        public static void SetLocalRotationX(this Transform tf, float value)
        {
            Vector3 rotation = tf.localEulerAngles;
            rotation.x = value;
            tf.localEulerAngles = rotation;
        }

        /// <summary>
        /// Set the local Y axis rotation (in degree)
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="value">New Y axis rotation value in degree</param>
        public static void SetLocalRotationY(this Transform tf, float value)
        {
            Vector3 rotation = tf.localEulerAngles;
            rotation.y = value;
            tf.localEulerAngles = rotation;
        }

        /// <summary>
        /// Set the local Z axis rotation (in degree)
        /// </summary>
        /// <param name="tf">Transform that calls the extension method</param>
        /// <param name="value">New Z axis rotation value in degree</param>
        public static void SetLocalRotationZ(this Transform tf, float value)
        {
            Vector3 rotation = tf.localEulerAngles;
            rotation.z = value;
            tf.localEulerAngles = rotation;
        }
        #endregion
    }
}
