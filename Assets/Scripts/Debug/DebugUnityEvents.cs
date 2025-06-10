using UnityEngine;

namespace RS.Utilities
{
    public class DebugUnityEvents : MonoBehaviour
    {
        public bool DebugAwake = true;
        public bool DebugStart;
        public bool DebugEnable;
        public bool DebugDisable = true;
        public bool DebugDestroy;

        public bool DebugCollision;
        [ConditionalHide(nameof(DebugCollision))]
        public bool DebugCollisionStay;

        public bool DebugTrigger;
        [ConditionalHide(nameof(DebugTrigger))]
        public bool DebugTriggerStay;

        // Standard unity event

        void Awake()
        {
            if (DebugAwake)
                Debug.Log("DebugUnityEvents: " + name + " - Awake", gameObject);
        }

        void Start()
        {
            if (DebugStart)
                Debug.Log("DebugUnityEvents: " + name + " - Start", gameObject);
        }

        void OnEnable()
        {
            if (DebugEnable)
                Debug.Log("DebugUnityEvents: " + name + " - Enable", gameObject);
        }

        void OnDisable()
        {
            if (DebugDisable)
                Debug.Log("DebugUnityEvents: " + name + " - Disable", gameObject);
        }

        void OnDestroy()
        {
            if (DebugDestroy)
                Debug.Log("DebugUnityEvents: " + name + " - Destroy", gameObject);
        }

        // Collision events

        private void OnCollisionEnter(Collision collision)
        {
            if (DebugCollision)
                Debug.Log("DebugUnityEvents: " + name + " - OnCollisionEnter", gameObject);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (DebugCollision && DebugCollisionStay)
                Debug.Log("DebugUnityEvents: " + name + " - OnCollisionStay", gameObject);
        }

        private void OnCollisionExit(Collision collision)
        {
            if (DebugCollision)
                Debug.Log("DebugUnityEvents: " + name + " - OnCollisionExit", gameObject);
        }

        // Trigger events

        private void OnTriggerEnter(Collider other)
        {
            if (DebugTrigger)
                Debug.Log("DebugUnityEvents: " + name + " - OnTriggerEnter", gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            if (DebugTrigger && DebugTriggerStay)
                Debug.Log("DebugUnityEvents: " + name + " - OnTriggerStay", gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            if (DebugTrigger)
                Debug.Log("DebugUnityEvents: " + name + " - OnTriggerExit", gameObject);
        }
    } 
}
