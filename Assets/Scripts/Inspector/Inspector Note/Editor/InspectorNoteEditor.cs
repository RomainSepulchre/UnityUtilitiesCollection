using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

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

namespace RS.Utilities.Editor
{
    [CustomEditor(typeof(InspectorNote))]
    public class InspectorNoteEditor : UnityEditor.Editor
    {
        // VARIABLES
        private InspectorNote _inspectorNote;

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

        private void OnEnable()
        {
            _inspectorNote = (InspectorNote)target;
            _selectedType = (TypeOfNote)_inspectorNote.noteType;
        }

        public override void OnInspectorGUI()
        {
            if (!_inspectorNote.isReady)
            {
                // User adding Input text in the inspector

                switch (_selectedType)
                {
                    case TypeOfNote.LineLabel:
                        if (EditorGUILayout.Toggle(_inspectorNote.isReady)) SwitchEditToggle(false);
                        {
                            EditorGUILayout.Space(10);
                            EditorGUILayout.LabelField(_inspectorNote.TextInfo); // A small line text
                            EditorGUILayout.Space(10);
                        }
                        break;

                    case TypeOfNote.BoxText:
                        if (GUILayout.Button(_buttonText)) SwitchEditToggle(false);
                        {
                            _buttonText = "INFO";
                            EditorGUILayout.Space(10);
                            EditorGUILayout.HelpBox(_inspectorNote.TextInfo, MessageType.None); // This is a small box
                            EditorGUILayout.Space(10);
                        }
                        break;

                    case TypeOfNote.BoxInfo:
                    default:
                        if (GUILayout.Button(_buttonText)) SwitchEditToggle(false);
                        {
                            _buttonText = "README";
                            EditorGUILayout.Space(10);
                            EditorGUILayout.HelpBox(_inspectorNote.TextInfo, MessageType.Info); // This is a help box
                            EditorGUILayout.Space(10);
                        }
                        break;

                    case TypeOfNote.BoxWarning:
                        if (GUILayout.Button(_buttonText)) SwitchEditToggle(false);
                        {
                            _buttonText = "ALERT";
                            EditorGUILayout.Space(10);
                            EditorGUILayout.HelpBox(_inspectorNote.TextInfo, MessageType.Warning); // This is a Warning box
                            EditorGUILayout.Space(10);
                        }
                        break;

                    case TypeOfNote.BoxError:
                        if (GUILayout.Button(_buttonText)) SwitchEditToggle(false);
                        {
                            _buttonText = "ERROR";
                            EditorGUILayout.Space(10);
                            EditorGUILayout.HelpBox(_inspectorNote.TextInfo, MessageType.Error); // This is a Error box
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
                if (GUILayout.Button(_buttonText)) SwitchEditToggle(true);

                EditorGUILayout.Space(10);

                // [ Input text ]
                _inspectorNote.TextInfo = EditorGUILayout.TextArea(_inspectorNote.TextInfo, GUILayout.MinHeight(50));

                EditorGUILayout.Space(10);

                // selection
                _selectedType = (TypeOfNote)EditorGUILayout.EnumPopup("Type of note: ", _selectedType);
                _inspectorNote.noteType = (int)_selectedType;

                EditorGUILayout.Space(10);

                // warning
                EditorGUILayout.HelpBox(" Press LOCK at the top when finish. ", MessageType.Warning); // A Warning box
            }
        }

        private void SwitchEditToggle(bool isInEditMode)
        {
            if (isInEditMode)
            {
                // Make scene dirty everytime we lock note, to be sure any change will be saved
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }    

            _inspectorNote.SwitchToggle();
        }
    } 
}