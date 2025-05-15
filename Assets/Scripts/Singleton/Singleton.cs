using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// A simple singleton (Replace any previous instance when instantiated)
    /// </summary>
    /// <typeparam name="T">Singleton type</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static T Instance { get; private set; }

        protected virtual void OnDestroy()
        {
            Instance = null;
        }

        protected void Awake()
        {
            SetSingleton(this as T);

            PostAwake();
        }

        /// <summary>
        /// Set the singleton, destroy and replace any previous instance of the singleton
        /// </summary>
        /// <param name="newInstance">New singleton instance</param>
        protected void SetSingleton(T newInstance)
        {
            if (Instance != null)
            {
                Debug.LogError("Singleton for " + typeof(T) + "already exist, destroying the old one");
                Destroy(Instance.gameObject);
            }

            Instance = newInstance;
        }

        /// <summary>
        /// Called at the end of Awake(), once the singleton has been set
        /// </summary>
        protected virtual void PostAwake() { }
    }

    /// <summary>
    /// A true singleton (the singleton create itself so we are sure there is only one instance and the instance is always available)
    /// </summary>
    /// <typeparam name="T">True singleton type</typeparam>
    public abstract class TrueSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        /// <summary>
        /// True singleton instance
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    CreateSingleton();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Instantiate the singleton and set it as DontDestroyOnLoad
        /// </summary>
        private static void CreateSingleton()
        {
            GameObject singleton = new GameObject(typeof(T) + " - Singleton");
            _instance = singleton.AddComponent<T>();

            DontDestroyOnLoad(singleton);
        }
    }
}