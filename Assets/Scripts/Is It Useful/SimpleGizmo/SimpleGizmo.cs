using UnityEngine;

namespace RS.Utilities
{
    public class SimpleGizmo : MonoBehaviour
    {
        public Color color;
        public bool fitCollider;

        public enum GizmoShape
        {
            Box,
            Sphere,
        }

        [ConditionalHide(nameof(fitCollider), true, true)]
        public GizmoShape shape;

        private void OnDrawGizmos()
        {
            Color oldColor = Gizmos.color;
            Gizmos.color = color;

            if(fitCollider)
            {
                ColliderGizmos();
            }
            else
            {
                switch (shape)
                {
                    case GizmoShape.Box:
                        Gizmos.DrawCube(transform.position, transform.lossyScale);
                        break;
                    case GizmoShape.Sphere:
                        Gizmos.DrawSphere(transform.position, Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z));
                        break;
                }
            }

            Gizmos.color = oldColor;
        }

        private void ColliderGizmos()
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            if (boxCollider)
            {
                Vector3 pos = transform.TransformPoint(boxCollider.center);
                Vector3 scale = Vector3.Scale(transform.lossyScale, boxCollider.size);

                Gizmos.DrawCube(pos, scale);
                return;
            }

            SphereCollider sphereCollider = GetComponent<SphereCollider>();
            if (sphereCollider)
            {
                Vector3 pos = transform.TransformPoint(sphereCollider.center);
                float radius = Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z) * sphereCollider.radius + 0.035f;

                Gizmos.DrawSphere(pos, radius);
                return;
            }
        }
    } 
}
