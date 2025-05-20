using RS.Utilities;
using System;
using UnityEngine;

namespace RS.Example
{
    public class EnumFlagExample : MonoBehaviour
    {
        // The enum doesn't have to use [Flags] but the enum value needs to be correctly set a flag usage
        public enum ExampleEnum
        {
            None = 0,
            One = 1, // 1 << 0
            Two = 2, // 1 << 1
            Three = 4, // 1 << 2
            VivaAlgerie = 8, // 1 << 4
        }

        [Header("Standard Enum GUI")]
        public ExampleEnum SimpleEnum;

        [Header("Use [EnumFlag] to display flag GUI")]
        [EnumFlag]
        public ExampleEnum EnumFlag;
    } 
}
