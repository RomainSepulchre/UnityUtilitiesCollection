using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// Automatically disable the game after the Awake()
    /// </summary>
    public class DisableOnAwake : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }
    }
}
