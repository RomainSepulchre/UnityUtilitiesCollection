using System;
using UnityEngine;
using UnityEngine.Events;

namespace RS.Utilities
{
    /// <summary>
    /// A simple script to start OnTrigger events on a gameObject with a 2D collider.
    /// The gameObject must have a Collider2D with 'isTrigger' enabled.
    /// </summary>
    public class OnTriggerEvents2D : MonoBehaviour
    {
        // To register events from the inspector
        [SerializeField] private UnityEvent _onTriggerEnter;
        [SerializeField] private UnityEvent _onTriggerStay;
        [SerializeField] private UnityEvent _onTriggerExit;

        // To register events from other scripts
        public event Action OnTriggerEnterEvent;
        public event Action OnTriggerStayEvent;
        public event Action OnTriggerExitEvent;

        public Collider2D LastTriggerEnter { get; private set; }
        public Collider2D LastTriggerStay { get; private set; }
        public Collider2D LastTriggerExit { get; private set; }

        private Collider2D _collider;

        private void Start()
        {
            // Ensure the gameObject has a Collider set to isTrigger
            bool success = TryGetComponent<Collider2D>(out _collider);

            if (!success)
            {
                Debug.LogError($"The gameObject doesn't have a collider2D, no OnTrigger events will be received on gameObjects that doesn't have collider2D with 'isTrigger' enabled");
            }
            else 
            {
                if (!_collider.enabled)
                {
                    Debug.LogWarning($"The gameObject collider2D is disabled, no OnTrigger events will be received on gameObjects with a disabled collider2D");
                }

                if (!_collider.isTrigger)
                {
                    Debug.LogError($"The gameObject collider2D 'isTrigger' option is not enabled, no OnTrigger events will be received on gameObjects that doesn't have collider2D with 'isTrigger' enabled");
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            LastTriggerEnter = collision;
            _onTriggerEnter?.Invoke();
            OnTriggerEnterEvent?.Invoke();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            LastTriggerStay = collision;
            _onTriggerStay?.Invoke();
            OnTriggerStayEvent?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            LastTriggerExit = collision;
            _onTriggerExit?.Invoke();
            OnTriggerExitEvent?.Invoke();
        }
    }
}
