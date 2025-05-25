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

        private enum EventMode
        {
            OneEvent = 0,
            EventList = 1,
        }

        private EventMode _selectedMode = EventMode.OneEvent;

        public override void OnInspectorGUI()
        {
            bool isPlaying = Application.isPlaying;

            _functionCaller = (FunctionCaller)target;

            _selectedMode = (EventMode)EditorGUILayout.EnumPopup("Event mode: ", _selectedMode);

            switch (_selectedMode)
            {
                case EventMode.OneEvent:
                default:
                    // Draw event field
                    serializedObject.Update();
                    EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(_functionCaller.Event)), true);
                    serializedObject.ApplyModifiedProperties();

                    if(_functionCaller.Event.GetPersistentEventCount() > 0)
                    {
                        if (!isPlaying) EditorGUILayout.LabelField($"Event can only be called in Play mode");
                        GUI.enabled = isPlaying;
                        if (GUILayout.Button($"Call event")) _functionCaller.Event.Invoke();
                        GUI.enabled = true;
                    }
                    else
                    {
                        EditorGUILayout.HelpBox("Add a function in the event", MessageType.Info);
                    }
                    break;

                case EventMode.EventList:
                    // Draw event list field
                    serializedObject.Update();
                    EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(_functionCaller.EventList)), true);
                    serializedObject.ApplyModifiedProperties();

                    if (_functionCaller.EventList.Count > 0)
                    {
                        bool playModeLabelAdded = false;
                        
                        for (int i = 0; i < _functionCaller.EventList.Count; i++)
                        {
                            UnityEvent ev = _functionCaller.EventList[i];
                            int functionCount = ev.GetPersistentEventCount();
                            int validEvent = 0;

                            if (functionCount > 0)
                            {
                                if (!isPlaying && !playModeLabelAdded)
                                {
                                    EditorGUILayout.LabelField($"Event can only be called in Play mode");
                                    playModeLabelAdded = true;
                                }

                                validEvent++;
                                StringBuilder sb = new StringBuilder($"{i}: ");
                                for (int j = 0; j < functionCount; j++)
                                {
                                    if (string.IsNullOrEmpty(ev.GetPersistentMethodName(j))) continue;
                                    if(sb.Length > 0) sb.Append(" + ");
                                    sb.Append($"{ev.GetPersistentMethodName(j)}");
                                }

                                GUI.enabled = isPlaying;
                                if (GUILayout.Button(sb.ToString()))
                                {
                                    ev.Invoke();
                                }
                                GUI.enabled = true;
                            }

                            if(validEvent <= 0) EditorGUILayout.HelpBox("Add a function in the event", MessageType.Info);
                        }
                    }
                    else
                    {
                        EditorGUILayout.HelpBox("Add an event in the list", MessageType.Info);
                    }
                    break;
            }
        }
    } 
}
