using UnityEngine;
using UnityEditor;

/*********************************************************
* 
*  2014-2019 Alan Mattano
*  SOARING STARS Lab
*  Inspector Note
*      
*      .Will handle the Information Note inspector variables
*      
*          . Make two stages {Input} / {visualisation}
*          . Visualize input and buttons in the inspector
* 
*  See https://github.com/ALanMAttano/UnityInspectorInfoTextNote
*  Modified by Romain Sepulchre
* *******************************************************/

[CustomEditor(typeof(InspectorNote))]
public class InspectorNoteEditor : Editor
{
    // VARIABLES
    private string _buttonText = "Start typing";

    private enum TypeOfNote
    {

        LineLabel = 0,
        BoxText = 1,
        BoxInfo = 2,
        BoxWarning = 3,
        BoxError = 4
    }

    private TypeOfNote _selectedType = TypeOfNote.BoxInfo;

    public override void OnInspectorGUI()
    {
        InspectorNote inMyScript = (InspectorNote)target;

        if (!inMyScript.isReady)
        {
            // User adding Input text in the inspector

            switch (_selectedType)
            {
                case TypeOfNote.LineLabel:
                    if (EditorGUILayout.Toggle(inMyScript.isReady)) inMyScript.SwitchToggle();
                    {
                        EditorGUILayout.Space(10);
                        EditorGUILayout.LabelField(inMyScript.TextInfo); // A small line text
                        EditorGUILayout.Space(10);
                    }
                    break;

                case TypeOfNote.BoxText:
                    if (GUILayout.Button(_buttonText)) inMyScript.SwitchToggle();
                    {
                        _buttonText = "INFO";
                        EditorGUILayout.Space(10);
                        EditorGUILayout.HelpBox(inMyScript.TextInfo, MessageType.None); // This is a small box
                        EditorGUILayout.Space(10);
                    }
                    break;

                case TypeOfNote.BoxInfo:
                default:
                    if (GUILayout.Button(_buttonText)) inMyScript.SwitchToggle();
                    {
                        _buttonText = "README";
                        EditorGUILayout.Space(10);
                        EditorGUILayout.HelpBox(inMyScript.TextInfo, MessageType.Info); // This is a help box
                        EditorGUILayout.Space(10);
                    }
                    break;

                case TypeOfNote.BoxWarning:
                    if (GUILayout.Button(_buttonText)) inMyScript.SwitchToggle();
                    {
                        _buttonText = "ALERT";
                        EditorGUILayout.Space(10);                                   
                        EditorGUILayout.HelpBox(inMyScript.TextInfo, MessageType.Warning); // This is a Warning box
                        EditorGUILayout.Space(10);                                   
                    }
                    break;

                case TypeOfNote.BoxError:
                    if (GUILayout.Button(_buttonText)) inMyScript.SwitchToggle();
                    {
                        _buttonText = "ERROR";
                        EditorGUILayout.Space(10);
                        EditorGUILayout.HelpBox(inMyScript.TextInfo, MessageType.Error); // This is a Error box
                        EditorGUILayout.Space(10);
                    }
                    break;                
            }
        }
        else
        {
            // Visualisation of final text in the inspector.

            _buttonText = "LOCK";

            // Display [ LOCK ] Button and switch if is press
            if (GUILayout.Button(_buttonText)) inMyScript.SwitchToggle();

            EditorGUILayout.Space(10);
            
            // [ Input text ]
            inMyScript.TextInfo = EditorGUILayout.TextArea(inMyScript.TextInfo, GUILayout.MinHeight(50));

            EditorGUILayout.Space(10);

            // selection
            _selectedType = (TypeOfNote)EditorGUILayout.EnumPopup("Type of note: ", _selectedType);

            EditorGUILayout.Space(10);

            // warning
            EditorGUILayout.HelpBox(" Press LOCK at the top when finish. ", MessageType.Warning); // A Warning box
        }
    }
}