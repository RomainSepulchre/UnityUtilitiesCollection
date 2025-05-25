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

		public List<NamedEvent> Events;

		// TODO: Does this work if disabled
		public void LogSomething(string log)
		{
			Debug.Log(log);
		}
	}  
}
#endif
