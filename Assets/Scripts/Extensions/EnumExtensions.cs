using System;
using UnityEngine;
using RS.Utilities;

namespace RS.Extensions
{
	public static class EnumExtensions
	{
        #region Extends any enum
        //public static T RandomEnumElement<T>(this Type enumType)
        //{
        //    string[] names = Enum.GetNames(enumType);
        //    string choice = names.RandomElement();
        //    return (T)Enum.Parse(enumType, choice);
        //}
        #endregion

        #region Extends a specific enum

        // Axis enum

        /// <summary>
        /// Returns the Vector3 corresponding to the axis calling the method
        /// </summary>
        /// <param name="axe">Axis that calls the extension method</param>
        /// <returns>Vector3 that corresponds to the axis</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Vector3 AsVector3(this Axis axe)
        {
            switch (axe)
            {
                case Axis.X:
                    return Vector3.right;

                case Axis.Y:
                    return Vector3.up;

                case Axis.Z:
                    return Vector3.forward;

                default:
                    throw new NotImplementedException();
            }
        }

        // CurveType Enum

        /// <summary>
        /// Get the Y value of a curve from its X value (from 0 to 1.0).
        /// </summary>
        /// <param name="curve">CurveType that calls the extension method</param>
        /// <param name="x">A float between 0 and 1.0, representing a X position on the curve</param>
        /// <returns>A float representing a Y position on the curve</returns>
        public static float Get(this CurveType curve, float x)
        {
            x = Mathf.Clamp01(x);
            switch (curve)
            {
                case CurveType.Sqrt:
                    return Mathf.Sqrt(x);

                case CurveType.FakeSqrt: //Similar to a square root, but easier on the cpu
                    return 1 - (1 - x) * (1 - x);

                case CurveType.Linear:
                    return x;

                case CurveType.Squared:
                    return x * x;

                case CurveType.SquaredEaseOut:
                    x = 1 - x;
                    return 1 - x * x;

                case CurveType.Cubed:
                    return x * x * x;

                case CurveType.CubedEaseOut:
                    x = 1 - x;
                    return 1 - x * x * x;

                case CurveType.Parabola:
                    return (x - x * x) * 4f;

                case CurveType.SmoothLinear: //Close to linear but with smooth start and end
                    return (3 * x * x - 2 * x * x * x); //3x² - 2x³

                case CurveType.SmoothEnd: //Close to linear but with smooth end
                    return (x + x * x - x * x * x); //x + x² - x³

                default:
                    Debug.Log("Unknown Curve Type");
                    return x;
            }
        }

        // TimeType Enum

        /// <summary>
        /// Returns the DeltaTime corresponding to the TimeType calling the method
        /// </summary>
        /// <param name="timeType">TimeType that call the extension method</param>
        /// <returns>DeltaTime value for this type of time</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static float DeltaTime(this TimeType timeType)
        {
            switch (timeType)
            {
                case TimeType.Normal:
                    return UnityEngine.Time.deltaTime;

                case TimeType.Unscaled:
                    return UnityEngine.Time.unscaledDeltaTime;

                case TimeType.Fixed:
                    return UnityEngine.Time.fixedDeltaTime;

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns the Time corresponding to the TimeType calling the method
        /// </summary>
        /// <param name="timeType">TimeType that call the extension method</param>
        /// <returns>Time value for this type of time</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static float Time(this TimeType timeType)
        {
            switch (timeType)
            {
                case TimeType.Normal:
                    return UnityEngine.Time.time;

                case TimeType.Unscaled:
                    return UnityEngine.Time.unscaledTime;

                case TimeType.Fixed:
                    return UnityEngine.Time.fixedTime;

                default:
                    throw new NotImplementedException();
            }
        }

        #endregion
    }
}
