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
    }
}
