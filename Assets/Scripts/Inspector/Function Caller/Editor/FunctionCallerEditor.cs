using System.Text;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.Events;

namespace RS.Utilities.Editor
{
    [CustomEditor(typeof(FunctionCaller))]
    public class FunctionCallerEditor : UnityEditor.Editor
    {
        private FunctionCaller _functionCaller;

        private int _lastEventCount;

        private void Reset()
        {
            _functionCaller = (FunctionCaller)target;
            _lastEventCount = _functionCaller.Events.Count;
        }

        public override void OnInspectorGUI()
        {
            bool isPlaying = Application.isPlaying;

            // Draw buttons
            int eventCount = _functionCaller.Events.Count;
            if (eventCount > 0)
            {
                bool playModeLabelAdded = false;
                int validEvent = 0;

                foreach (var namedEvent in _functionCaller.Events)
                {
                    UnityEvent ev = namedEvent.Event;
                    int functionCount = ev.GetPersistentEventCount();

                    if (functionCount > 0)
                    {
                        validEvent++;
                        if (!isPlaying && !playModeLabelAdded)
                        {
                            EditorGUILayout.HelpBox($"Event can only be called in Play mode", MessageType.None);
                            playModeLabelAdded = true;
                        }

                        GUI.enabled = isPlaying;
                        if (GUILayout.Button(namedEvent.Name)) ev.Invoke();
                        GUI.enabled = true;
                    }
                }

                if (validEvent <= 0) EditorGUILayout.HelpBox("Create an event, name it and set the functions you want to call.", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox("Create an event, name it and set the functions you want to call.", MessageType.Info);
            }

            EditorGUILayout.Space(10);

            // Draw event name field
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(_functionCaller.Events)), true);
            serializedObject.ApplyModifiedProperties();

            // Auto-name new events
            int updatedEventCount = _functionCaller.Events.Count;
            if (updatedEventCount > _lastEventCount)
            {
                string eventName = _functionCaller.Events[updatedEventCount - 1].Name;

                // Rename if name is empty or same as previous entry
                if(string.IsNullOrEmpty(eventName) || eventName == _functionCaller.Events[updatedEventCount - 2].Name)
                { 
                    _functionCaller.Events[updatedEventCount - 1].Name = $"Event #{updatedEventCount - 1}";
                }
            }

            _lastEventCount = _functionCaller.Events.Count;
        }
    } 
}
