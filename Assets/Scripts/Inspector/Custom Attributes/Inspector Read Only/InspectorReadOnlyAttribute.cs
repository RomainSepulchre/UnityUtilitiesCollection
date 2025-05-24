using System;
using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// Prevent to modify the data of the field from the inspector
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
	public class InspectorReadOnlyAttribute : PropertyAttribute
	{

	} 
}
