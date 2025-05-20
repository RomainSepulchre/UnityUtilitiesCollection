using System;
using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// Use the flags GUI for the enum and enable flag feature such as multi-selection even if the enum is not stated as a flag.
    /// The enum doesn't need to use [Flags] but the enum value needs to be set correctly for a flag usage (0,1,2,4,8,...).
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumFlagAttribute : PropertyAttribute
	{

	} 
}
