using RS.Extensions;
using RS.Utilities;
using UnityEngine;

namespace RS.Example
{
    public class MathExtensionsExample : MonoBehaviour
    {
        public enum RotateTowardMode
        {
            ByPercentStep,
            ByDegreeStep,
            Instantaneous
        }

        [Header("GameObjects")]
        public Transform TransformA;
        public Transform TransformB;
        public Transform CubeTf;
        public Transform RotateToward;

        [Header("Rotate Toward Options")]
        public RotateTowardMode RotateMode;
        [ConditionalHide(nameof(RotateMode), RotateTowardMode.ByPercentStep)]
        [AsPercentage] public float RotatePercentage;
        [ConditionalHide(nameof(RotateMode), RotateTowardMode.ByDegreeStep)]
        [Range(0, 180)]public float RotateDegree;


        [Header("Squared magnitude between two position: move TransformA or TransformB to update the values")]
        public float SqMagnitudeAToBWithTransform;
        public float SqMagnitudeAToBWithVector;

        [Space(10)]
        public float XzSqMagnitudeAToBWithTransform;
        public float XzSqMagnitudeAToBWithVector;     

        [Space(10)]
        public float XySqMagnitudeAToBWithTransform;
        public float XySqMagnitudeAToBWithVector;
        
        [Space(10)]
        public float YzSqMagnitudeAToBWithTransform;
        public float YzSqMagnitudeAToBWithVector;

        [Header("Squared magnitude of a vector: move TransformA to update the values")]
        public float XzSqMagnitudeOfA;
        public float XzMagnitudeOfA;

        [Space(10)]
        public float XySqMagnitudeOfA;
        public float XyMagnitudeOfA;

        [Space(10)]
        public float YzSqMagnitudeOfA;
        public float YzMagnitudeOfA;

        [Header("Angles: move and rotate TransformA or TransformB to update the values")]
        public float YAngleAToB;
        public float YAngleBetweenAAndBForward;
        public float YAngleOfA;

        [Header("Set Local Scale: move Cube to update its scale (scale is tied to position and clamped to a minimum of 0.1f)")]
        public bool EnableCubeScale;
        [ConditionalHide(nameof(EnableCubeScale), true)]
        public Vector3 CubeLocalScale;

        
        [Header("Set Local Angle: move Cube to update its rotation (rotation is tied to position)")]
        public bool EnableCubeRotation;
        [ConditionalHide(nameof(EnableCubeRotation), true)]
        public Vector3 CubeLocalEulerAngles;

        void Update()
        {
            // Global Squared Magnitude
            SqMagnitudeAToBWithTransform = TransformA.SqrMagnitudeWith(TransformB);
            SqMagnitudeAToBWithVector = TransformA.position.SqrMagnitudeWith(TransformB.position);

            // XZ Squared Magnitude
            XzSqMagnitudeAToBWithTransform = TransformA.XzSqrMagnitudeWith(TransformB);
            XzSqMagnitudeAToBWithVector = TransformA.position.XzSqrMagnitudeWith(TransformB.position);
            XzSqMagnitudeOfA = TransformA.position.XzSqrMagnitude();
            XzMagnitudeOfA = TransformA.position.XzMagnitude();

            // XY Squared Magnitude
            XySqMagnitudeAToBWithTransform = TransformA.XySqrMagnitudeWith(TransformB);
            XySqMagnitudeAToBWithVector = TransformA.position.XySqrMagnitudeWith(TransformB.position);
            XySqMagnitudeOfA = TransformA.position.XySqrMagnitude();
            XyMagnitudeOfA = TransformA.position.XyMagnitude();

            // YZ Squared Magnitude
            YzSqMagnitudeAToBWithTransform = TransformA.YzSqrMagnitudeWith(TransformB);
            YzSqMagnitudeAToBWithVector = TransformA.position.YzSqrMagnitudeWith(TransformB.position);
            YzSqMagnitudeOfA = TransformA.position.YzSqrMagnitude();
            YzMagnitudeOfA = TransformA.position.YzMagnitude();

            // Angles
            YAngleAToB = TransformA.AngleWith(TransformB);
            YAngleBetweenAAndBForward = TransformA.forward.AngleWith(TransformB.forward);
            YAngleOfA = TransformA.position.Angle();

            // Change Cube Scale
            if (EnableCubeScale)
            {
                CubeTf.SetLocalScaleX(Mathf.Clamp(CubeTf.position.x * Mathf.Sign(CubeTf.position.x), 0.1f, float.PositiveInfinity));
                CubeTf.SetLocalScaleY(Mathf.Clamp(CubeTf.position.y * Mathf.Sign(CubeTf.position.y), 0.1f, float.PositiveInfinity));
                CubeTf.SetLocalScaleZ(Mathf.Clamp(CubeTf.position.z * Mathf.Sign(CubeTf.position.z), 0.1f, float.PositiveInfinity));
            }
            CubeLocalScale = CubeTf.localScale;

            // Change Cube Scale
            if(EnableCubeRotation)
            {
                // *25f to make rotation more visible
                CubeTf.SetLocalRotationX(CubeTf.position.x * 25f);
                CubeTf.SetLocalRotationY(CubeTf.position.y * 25f);
                CubeTf.SetLocalRotationZ(CubeTf.position.z * 25f);
            }
            CubeLocalEulerAngles = CubeTf.localEulerAngles;

            // Rotate Toward
            switch (RotateMode)
            {
                case RotateTowardMode.ByPercentStep:
                    RotateToward.RotateTowardPercent(Vector3.zero, RotatePercentage);
                    break;
                case RotateTowardMode.ByDegreeStep:
                    RotateToward.RotateToward(Vector3.zero, RotateDegree);
                    break;
                default:
                case RotateTowardMode.Instantaneous:
                    RotateToward.RotateToward(Vector3.zero);
                    break;
            }
        }

        private void OnDrawGizmos()
        {
            Vector3 posA = TransformA.position;
            Vector3 posB = TransformB.position;

            Vector3 markerXOffset = new Vector3(0.25f, 0, 0);
            Vector3 markerZOffset = new Vector3(0, 0, 0.25f);

            // Draw transform A
            Debug.DrawLine(Vector3.zero, posA, Color.black);
            Debug.DrawLine(posA + -markerXOffset, posA + markerXOffset, Color.yellow);
            Debug.DrawLine(posA + -markerZOffset, posA + markerZOffset, Color.yellow);
            Debug.DrawLine(posA, posA + TransformA.forward, Color.beige);

            // Draw transform B
            Debug.DrawLine(Vector3.zero, posB, Color.black);
            Debug.DrawLine(posB + -markerXOffset, posB + markerXOffset, Color.yellow);
            Debug.DrawLine(posB + -markerZOffset, posB + markerZOffset, Color.yellow);
            Debug.DrawLine(posB, posB + TransformB.forward, Color.beige);

            // Draw A to B
            Debug.DrawLine(posA, posB, Color.gray);
        }
    } 
}
