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
		public UnityEvent Event;

		public List<UnityEvent> EventList;

		// TODO: Does this work if disabled
		public void LogSomething(string log)
		{
			Debug.Log(log);
		}
	}  
}
#endif
