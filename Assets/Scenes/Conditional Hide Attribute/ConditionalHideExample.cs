using RS.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RS.Example
{
    public class ConditionalHideExample : MonoBehaviour
    {
        [Serializable]
        public class SerializedClass
        {
            public int SomeInt;
            public bool UseSomething;
            public string SomeString;
            public Vector3 Position;
            public GameObject GameObject;
            public List<float> FloatList;
            public string[] StringArray;
        }

        [Header("Conditional hide")]
        public bool ConditionToShow;

        [ConditionalHide(nameof(ConditionToShow), true)]
        public int SomeIntA;
        [ConditionalHide(nameof(ConditionToShow), true)]
        public bool UseSomethingA;
        [ConditionalHide(nameof(ConditionToShow), true)]
        public string SomeStringA;
        [ConditionalHide(nameof(ConditionToShow), true)]
        public Vector3 PositionA;
        [ConditionalHide(nameof(ConditionToShow), true)]
        public GameObject GameObjectA;
        [ConditionalHide(nameof(ConditionToShow), true)]
        public List<float> FloatListA;
        [ConditionalHide(nameof(ConditionToShow), true)]
        public string[] StringArrayA;
        [ConditionalHide(nameof(ConditionToShow), true)]
        public SerializedClass SerializedClassA;

        [Space(30)]

        [Header("Conditional enable")]
        public bool ConditionToEnable;

        [ConditionalHide(nameof(ConditionToEnable))]
        public int SomeIntB;
        [ConditionalHide(nameof(ConditionToEnable))]
        public bool UseSomethingB;
        [ConditionalHide(nameof(ConditionToEnable))]
        public string SomeStringB;
        [ConditionalHide(nameof(ConditionToEnable))]
        public Vector3 PositionB;
        [ConditionalHide(nameof(ConditionToEnable))]
        public GameObject GameObjectB;
        [ConditionalHide(nameof(ConditionToEnable))]
        public List<float> FloatListB;
        [ConditionalHide(nameof(ConditionToEnable))]
        public string[] StringArrayB;
        [ConditionalHide(nameof(ConditionToEnable))]
        public SerializedClass SerializedClassB;

        [Space(30)]

        [Header("Multi-Conditional hide")]
        public bool ConditionAToShow;
        public bool ConditionBToShow;

        [ConditionalHide(new string[] {nameof(ConditionAToShow), nameof(ConditionBToShow) } , true, false)]
        public int SomeIntC;
        [ConditionalHide(new string[] { nameof(ConditionAToShow), nameof(ConditionBToShow) }, true, false)]
        public bool UseSomethingC;
        [ConditionalHide(new string[] { nameof(ConditionAToShow), nameof(ConditionBToShow) }, true, false)]
        public string SomeStringC;
        [ConditionalHide(new string[] { nameof(ConditionAToShow), nameof(ConditionBToShow) }, true, false)]
        public Vector3 PositionC; 
        [ConditionalHide(new string[] { nameof(ConditionAToShow), nameof(ConditionBToShow) }, true, false)]
        public GameObject GameObjectC;
        [ConditionalHide(new string[] { nameof(ConditionAToShow), nameof(ConditionBToShow) }, true, false)]
        public List<float> FloatListC;
        [ConditionalHide(new string[] { nameof(ConditionAToShow), nameof(ConditionBToShow) }, true, false)]
        public string[] StringArrayC;
        [ConditionalHide(new string[] { nameof(ConditionAToShow), nameof(ConditionBToShow) }, true, false)]
        public SerializedClass SerializedClassC;

        [Space(30)]

        [Header("Multi-Conditional enable")]
        public bool ConditionAToEnable;
        public bool ConditionBToEnable;

        [ConditionalHide(new string[] { nameof(ConditionAToEnable), nameof(ConditionBToEnable) }, false, false)]
        public int SomeIntD;
        [ConditionalHide(new string[] { nameof(ConditionAToEnable), nameof(ConditionBToEnable) }, false, false)]
        public bool UseSomethingD;
        [ConditionalHide(new string[] { nameof(ConditionAToEnable), nameof(ConditionBToEnable) }, false, false)]
        public string SomeStringD;
        [ConditionalHide(new string[] { nameof(ConditionAToEnable), nameof(ConditionBToEnable) }, false, false)]
        public Vector3 PositionD;       
        [ConditionalHide(new string[] { nameof(ConditionAToEnable), nameof(ConditionBToEnable) }, false, false)]
        public GameObject GameObjectD;
        [ConditionalHide(new string[] { nameof(ConditionAToEnable), nameof(ConditionBToEnable) }, false, false)]
        public List<float> FloatListD;
        [ConditionalHide(new string[] { nameof(ConditionAToEnable), nameof(ConditionBToEnable) }, false, false)]
        public string[] StringArrayD;
        [ConditionalHide(new string[] { nameof(ConditionAToEnable), nameof(ConditionBToEnable) }, false, false)]
        public SerializedClass SerializedClassD;

        [Space(30)]

        [Header("Use object reference as condition")]
        public GameObject ObjectRefCondition;

        [ConditionalHide(nameof(ObjectRefCondition))]
        public int SomeIntE;
        [ConditionalHide(nameof(ObjectRefCondition))]
        public bool UseSomethingE;
        [ConditionalHide(nameof(ObjectRefCondition))]
        public string SomeStringE;
        [ConditionalHide(nameof(ObjectRefCondition))]
        public Vector3 PositionE;
        [ConditionalHide(nameof(ObjectRefCondition))]
        public GameObject GameObjectE;
        [ConditionalHide(nameof(ObjectRefCondition))]
        public List<float> FloatListE;
        [ConditionalHide(nameof(ObjectRefCondition))]
        public string[] StringArrayE;
        [ConditionalHide(nameof(ObjectRefCondition))]
        public SerializedClass SerializedClassE;

        [Space(30)]

        [Header("Multi-Conditional with object reference")]
        public bool ConditionAObjRef;
        public GameObject ConditionBObjRef;

        [ConditionalHide(new string[] { nameof(ConditionAObjRef), nameof(ConditionBObjRef) }, false, false)]
        public int SomeIntF;
        [ConditionalHide(new string[] { nameof(ConditionAObjRef), nameof(ConditionBObjRef) }, false, false)]
        public bool UseSomethingF;
        [ConditionalHide(new string[] { nameof(ConditionAObjRef), nameof(ConditionBObjRef) }, false, false)]
        public string SomeStringF;
        [ConditionalHide(new string[] { nameof(ConditionAObjRef), nameof(ConditionBObjRef) }, false, false)]
        public Vector3 PositionF;
        [ConditionalHide(new string[] { nameof(ConditionAObjRef), nameof(ConditionBObjRef) }, false, false)]
        public GameObject GameObjectF;
        [ConditionalHide(new string[] { nameof(ConditionAObjRef), nameof(ConditionBObjRef) }, false, false)]
        public List<float> FloatListF;
        [ConditionalHide(new string[] { nameof(ConditionAObjRef), nameof(ConditionBObjRef) }, false, false)]
        public string[] StringArrayF;
        [ConditionalHide(new string[] { nameof(ConditionAObjRef), nameof(ConditionBObjRef) }, false, false)]
        public SerializedClass SerializedClassF;

        [Space(30)]

        [Header("Hide/Disable field without condition")]
        [ConditionalHide(false)]
        public int intDisabled;
        [ConditionalHide(true)]
        public int intHidden; // Should not be seen in the inspector since its hidden

        [Space(30)]

        [Header("Test specific constructors")]
        public bool testConditionA;
        public bool testConditionB;

        // Should be disabled when condition not met
        [ConditionalHide(new string[] { nameof(testConditionA), nameof(testConditionB) })]
        public int intCtrOnlyConditionArray;

        // Should be hiddent when condition not met
        [ConditionalHide(new string[] { nameof(testConditionA), nameof(testConditionB) }, true)]
        public int intCtrConditionArrayAndHideBool;

        //
        [ConditionalHide(ConditionalSourceField = nameof(testConditionA))]
        public int intCondProp; // Should not be seen in the inspector since its hidden
    } 
}
