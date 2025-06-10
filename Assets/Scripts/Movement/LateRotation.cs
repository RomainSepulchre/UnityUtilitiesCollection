using RS.Extensions;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

namespace RS.Utilities
{
    /// <summary>
    /// Rotate the object around a specific axis. Processed in the LateUpdate.
    /// </summary>
    public class LateRotation : MonoBehaviour
    {
        public Axis Axe;
        public float RotationAngle;

        public TimeType Time;

        private void LateUpdate()
        {
            float delta = Time.DeltaTime();

            switch (Axe)
            {
                case Axis.X:
                    transform.Rotate(Vector3.right, RotationAngle * delta);
                    break;

                case Axis.Y:
                    transform.Rotate(Vector3.up, RotationAngle * delta);
                    break;

                case Axis.Z:
                    transform.Rotate(Vector3.forward, RotationAngle * delta);
                    break;
            }
        }
    } 
}
