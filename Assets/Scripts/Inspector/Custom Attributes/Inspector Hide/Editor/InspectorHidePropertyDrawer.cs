using UnityEditor;
using UnityEngine;

namespace RS.Utilities.Editor
{
    [CustomPropertyDrawer(typeof(InspectorHideAttribute))]
    public class InspectorHidePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return -EditorGUIUtility.standardVerticalSpacing;
        }
    } 
}
