using UnityEditor;
using UnityEngine;

namespace RS.Utilities.Editor
{
    [CustomPropertyDrawer(typeof(AsPercentageAttribute))]
    public class AsPercentagePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            AsPercentageAttribute percentage = (AsPercentageAttribute)attribute;

            if(percentage.ShowMinMax)
            {
                label = new GUIContent($"{label.text} (%: {percentage.Min}->{percentage.Max})");
            }
            else
            {
                label = new GUIContent($"{label.text} (%)");
            }

            float value0To1 = Mathf.InverseLerp(percentage.Min, percentage.Max, property.floatValue);
            float sliderAsPercentage = EditorGUI.Slider(position, label, value0To1 * 100f, 0f, 100f);
            property.floatValue = Mathf.Lerp(percentage.Min, percentage.Max, sliderAsPercentage / 100f);
        }
    } 
}
