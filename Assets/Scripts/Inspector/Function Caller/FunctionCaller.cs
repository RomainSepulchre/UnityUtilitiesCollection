using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
namespace RS.Utilities
{
	/// <summary>
	/// Link an event to a GUI button to easily call a set of functions by invoking the event
	/// </summary>
	[AddComponentMenu("Utilities/Function Caller")]
	public class FunctionCaller : MonoBehaviour
	{
		[Serializable]
		public class NamedEvent
		{
			public string Name;
			public UnityEvent Event;
        }

		public List<NamedEvent> Events = new List<NamedEvent>();

        private void Awake()
        {
            // Disable this component when game start, button and event works even when component is disabled
            this.enabled = false; 
        }
    }  
}
#endif
