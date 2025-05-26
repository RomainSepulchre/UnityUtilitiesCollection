using NUnit.Framework.Internal;
using RS.Extensions;
using RS.Utilities;
using System;
using UnityEngine;

namespace RS.Example
{
    public class EnumExtensionsExample : MonoBehaviour
    {
        public enum EnumForRandomElement
        {
            A,
            B,
            C,
            D,
            E,
        }

        [Header("Play scene to see processed values")]
        [InspectorHide] public bool IgnoreMeIJustMakeHeaderVisibleA; // Only to show header

        [Space(20)]

        [Header("Get a random value from an enum type")]
        [InspectorReadOnly] public EnumForRandomElement RandomEnumValue;

        [Space(20)]

        [Header("Axis Enum")]
        public Axis MyAxis;
        [InspectorReadOnly] public Vector3 AxisAsVector;

        [Space(20)]

        [Header("CurveType Enum")]
        public CurveType MyCurveType;
        [Range(0f,1f)] public float CurveXValue = 0.5f;
        [InspectorReadOnly] public float CurveYValue;

        [Space(20)]

        public TimeType MyTimeType;
        [InspectorReadOnly] public float DeltaTimeValue;
        [InspectorReadOnly] public float TimeValue;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            RandomEnumValue = typeof(EnumForRandomElement).RandomEnumElement<EnumForRandomElement>();
            // Another way of doing it
            // RandomEnumElement = RandomEnumElement.GetType().RandomEnumElement<EnumForRandomElement>();
        }

        // Update is called once per frame
        void Update()
        {
            AxisAsVector = MyAxis.AsVector3();

            CurveYValue = MyCurveType.Get(CurveXValue);

            DeltaTimeValue = MyTimeType.DeltaTime();
            TimeValue = MyTimeType.Time();
        }
    } 
}
