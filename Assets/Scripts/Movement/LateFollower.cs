using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// Follow a target. Processed in the LateUpdate.
    /// </summary>
    public class LateFollower : MonoBehaviour
    {
        public Transform ToFollow;

        [Range(0.9f, 1f)]
        public float FollowPercent = 0.99f;

        public float RateTime = 0.08f;

        private void LateUpdate()
        {
            Quaternion rot = ToFollow.rotation;
            Quaternion arRot = transform.rotation;

            Vector3 pos = ToFollow.position;
            Vector3 arPos = transform.position;

            float t = 1 - Mathf.Pow(1 - FollowPercent, Time.unscaledDeltaTime / RateTime);

            transform.position = Vector3.Lerp(arPos, pos, t);
            transform.rotation = Quaternion.Lerp(arRot, rot, t);
        }
    } 
}
