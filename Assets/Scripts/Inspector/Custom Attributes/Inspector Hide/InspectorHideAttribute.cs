using System;
using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// Hide and disable the field in the inspector but keep the field <i>[Header]</i> visible contrary to <i>[HideInInspector]</i>.
    /// <b>If you only need to hide the field, <i>[HideInInspector]</i> is probably more relevant in most of the case.</b>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
	public class InspectorHideAttribute : PropertyAttribute
	{

	} 
}
