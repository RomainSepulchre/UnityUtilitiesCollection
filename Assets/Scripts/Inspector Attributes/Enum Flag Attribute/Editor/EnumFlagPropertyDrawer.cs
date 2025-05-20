using RS.Utilities;
using System;
using UnityEditor;
using UnityEngine;

namespace RS.Utilities.Editor
{
    [CustomPropertyDrawer(typeof(EnumFlagAttribute))]
    public class EnumFlagPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);

            Enum oldValue = (Enum)fieldInfo.GetValue(property.serializedObject.targetObject);
            Enum newValue = EditorGUI.EnumFlagsField(position, label, oldValue);

            if(!newValue.Equals(oldValue))
            {
                property.intValue = (int)Convert.ChangeType(newValue, fieldInfo.FieldType);
            }

            EditorGUI.EndProperty();
        }
    } 
}
