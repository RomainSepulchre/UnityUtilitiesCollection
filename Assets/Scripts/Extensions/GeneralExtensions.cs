using RS.Utilities;
using System;
using System.Collections;
using UnityEngine;

namespace RS.Extensions
{
    public static class GeneralExtensions
    {
        #region Monobehaviour
        /// <summary>
        /// Start a couroutine to call an action after a specified amount of time
        /// </summary>
        /// <param name="monoBehaviour">Monobehaviour that call the extension method</param>
        /// <param name="action">Action to invoke</param>
        /// <param name="time">Amount of time to wait before calling the action </param>
        /// <returns></returns>
        public static Coroutine Invoke(this MonoBehaviour monoBehaviour, System.Action action, float time)
        {
            return monoBehaviour.StartCoroutine(InvokeImpl(action, time));
        }

        private static IEnumerator InvokeImpl(System.Action action, float time)
        {
            yield return new WaitForSeconds(time);

            action();
        }
        #endregion

        #region Time enums

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
