using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// Automatically destroy a gameObject after an amount of time
    /// </summary>
    public class DestroyIn : MonoBehaviour
    {
        /// <summary>
        /// Delay before the gameObject destruction (in seconds)
        /// </summary>
        public float DestroyDelay;

        /// <summary>
        /// Should we ignore the time scale
        /// </summary>
        public bool IgnoreTimeScale;

        private float _startTime;

        void Start()
        {
            _startTime = IgnoreTimeScale ? Time.unscaledTime : Time.time;
        }

        void Update()
        {
            if(_startTime + DestroyDelay < (IgnoreTimeScale ? Time.unscaledTime : Time.time))
            {
                Destroy(gameObject);
            }
        }
    } 
}
