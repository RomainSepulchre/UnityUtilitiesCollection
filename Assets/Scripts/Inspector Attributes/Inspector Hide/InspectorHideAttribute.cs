using System;
using UnityEngine;

namespace RS.Utilities
{
	/// <summary>
	/// Hide and disable the field in the inspector
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class InspectorHideAttribute : PropertyAttribute
	{

	} 
}
