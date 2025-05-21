using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace RS.Utilities
{
    /// <summary>
    /// A simple script to start OnTrigger events on a gameObject with a collider.
    /// The gameObject must have a Collider with 'isTrigger' enabled.
    /// </summary>
    public class OnTriggerEvents : MonoBehaviour
    {
        // To register events from the inspector
        [SerializeField] private UnityEvent _onTriggerEnter;
        [SerializeField] private UnityEvent _onTriggerStay;
        [SerializeField] private UnityEvent _onTriggerExit;

        // To register events from other scripts
        public event Action OnTriggerEnterEvent;
        public event Action OnTriggerStayEvent;
        public event Action OnTriggerExitEvent;

        public Collider LastTriggerEnter { get; private set; }
        public Collider LastTriggerStay { get; private set; }
        public Collider LastTriggerExit { get; private set; }

        private Collider _collider;

        private void Start()
        {
            // Ensure the gameObject has a Collider set to isTrigger
            bool success = TryGetComponent<Collider>(out Collider _collider);

            if(!success)
            {
                Debug.LogError($"The gameObject doesn't have a collider, no OnTrigger events will be received on gameObjects that doesn't have collider with 'isTrigger' enabled");
            }
            else 
            {
                if (!_collider.enabled)
                {
                    Debug.LogWarning($"The gameObject collider is disabled, no OnTrigger events will be received on gameObjects with a disabled collider");
                }

                if (!_collider.isTrigger)
                {
                    Debug.LogError($"The gameObject collider 'isTrigger' option is not enabled, no OnTrigger events will be received on gameObjects that doesn't have collider with 'isTrigger' enabled");

                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            LastTriggerEnter = other;
            _onTriggerEnter?.Invoke();
            OnTriggerEnterEvent?.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            LastTriggerStay = other;
            _onTriggerStay?.Invoke();
            OnTriggerStayEvent?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            LastTriggerExit = other;
            _onTriggerExit?.Invoke();
            OnTriggerExitEvent?.Invoke();
        }
    }
}
