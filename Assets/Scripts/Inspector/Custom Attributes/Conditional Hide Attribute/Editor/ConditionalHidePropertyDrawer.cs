using System;
using UnityEditor;
using UnityEngine;

//Original version of the ConditionalHideAttribute created by Brecht Lecluyse (www.brechtos.com)
// See https://www.brechtos.com/hiding-or-disabling-inspector-properties-using-propertydrawers-within-unity-5/
//Modified by: Romain Sepulchre

namespace RS.Utilities.Editor
{
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHidePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            ConditionalHideAttribute condHAtt = (ConditionalHideAttribute)attribute;
            bool enabled = GetConditionalHideAttributeResult(condHAtt, property);

            bool wasEnabled = GUI.enabled;
            GUI.enabled = enabled;
            if (!condHAtt.HideInInspector || enabled)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }

            GUI.enabled = wasEnabled;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ConditionalHideAttribute condHAtt = (ConditionalHideAttribute)attribute;
            bool enabled = GetConditionalHideAttributeResult(condHAtt, property);

            if (!condHAtt.HideInInspector || enabled)
            {
                return EditorGUI.GetPropertyHeight(property, label);
            }
            else
            {
                //The property is not being drawn
                //We want to undo the spacing added before and after the property
                return -EditorGUIUtility.standardVerticalSpacing;
            }
        }

        /// <summary>
        /// Get the conditions from the Conditional Hide Attribute and returns if the field should be enabled
        /// </summary>
        /// <param name="condHAtt">Conditional Hide Attribute</param>
        /// <param name="property">Property of the field</param>
        /// <returns>Wether the field should be enabled</returns>
        private bool GetConditionalHideAttributeResult(ConditionalHideAttribute condHAtt, SerializedProperty property)
        {
            bool enabled = (condHAtt.UseOrLogic) ? false : true; // Necessary to deal with multiple condition (Maybe could be done elsewhere for more clarity)

            //Handle primary property
            SerializedProperty sourcePropertyValue = null;

            //Get the full relative property path of the sourcefield so we can have nested hiding. Use old method when dealing with arrays.
            if (!property.isArray)
            {
                string propertyPath = property.propertyPath; //returns the property path of the property we want to apply the attribute to
                string conditionPath = propertyPath.Replace(property.name, condHAtt.ConditionalSourceField); //changes the path to the conditionalsource property path
                sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

                //if the find failed->fall back to the old system
                if (sourcePropertyValue == null)
                {
                    //original implementation (doens't work with nested serializedObjects)
                    sourcePropertyValue = property.serializedObject.FindProperty(condHAtt.ConditionalSourceField);
                }
            }
            else
            {
                //original implementation (doens't work with nested serializedObjects)
                sourcePropertyValue = property.serializedObject.FindProperty(condHAtt.ConditionalSourceField);
            }


            if (sourcePropertyValue != null)
            {
                enabled = GetConditionFromPropertyType(sourcePropertyValue, condHAtt.ObjToCompare);
            }
            else
            {
                //Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: " + condHAtt.ConditionalSourceField);
            }

            //Handle the unlimited property array
            string[] conditionalSourceFieldArray = condHAtt.ConditionalSourceFields;
            bool[] conditionalSourceFieldInverseArray = condHAtt.ConditionalSourceFieldInverseBools;
            object[] conditionalSourceFieldsObjsToCompare = condHAtt.ConditionalSourceFieldsObjsToCompare;
            for (int index = 0; index < conditionalSourceFieldArray.Length; ++index)
            {
                SerializedProperty sourcePropertyValueFromArray = null;
                if (!property.isArray)
                {
                    string propertyPath = property.propertyPath; //returns the property path of the property we want to apply the attribute to
                    string conditionPath = propertyPath.Replace(property.name, conditionalSourceFieldArray[index]); //changes the path to the conditionalsource property path
                    sourcePropertyValueFromArray = property.serializedObject.FindProperty(conditionPath);

                    //if the find failed->fall back to the old system
                    if (sourcePropertyValueFromArray == null)
                    {
                        //original implementation (doens't work with nested serializedObjects)
                        sourcePropertyValueFromArray = property.serializedObject.FindProperty(conditionalSourceFieldArray[index]);
                    }
                }
                else
                {
                    // original implementation(doens't work with nested serializedObjects) 
                    sourcePropertyValueFromArray = property.serializedObject.FindProperty(conditionalSourceFieldArray[index]);
                }

                //Combine the results
                if (sourcePropertyValueFromArray != null)
                {
                    object objToCompare = conditionalSourceFieldsObjsToCompare.Length >= (index + 1) ? conditionalSourceFieldsObjsToCompare[index] : null;
                    bool propertyEnabled = GetConditionFromPropertyType(sourcePropertyValueFromArray, objToCompare);
                    if (conditionalSourceFieldInverseArray.Length >= (index + 1) && conditionalSourceFieldInverseArray[index]) propertyEnabled = !propertyEnabled;

                    if (condHAtt.UseOrLogic)
                        enabled = enabled || propertyEnabled;
                    else
                        enabled = enabled && propertyEnabled;
                }
                else
                {
                    //Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: " + condHAtt.ConditionalSourceField);
                }
            }


            //wrap it all up
            if (condHAtt.Inverse) enabled = !enabled;

            return enabled;
        }

        /// <summary>
        /// Return the condition by checking the property type. Additional condition types can be added here.
        /// </summary>
        /// <param name="sourcePropertyValue">Serialized property of our condition field</param>
        /// <returns>Condition to show/enable field</returns>
        private bool GetConditionFromPropertyType(SerializedProperty sourcePropertyValue, object objToCompare)
        {
            //Note: add others for custom handling if desired
            switch (sourcePropertyValue.propertyType)
            {
                // MAIN PROPERTY TYPE

                case SerializedPropertyType.Boolean:
                    if (objToCompare != null && objToCompare is bool)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.boolValue.ToString();
                    }
                    else return sourcePropertyValue.boolValue;

                case SerializedPropertyType.ObjectReference:
                    if (objToCompare != null) // If there is an object to compare, check if it's the same object
                    {
                        return objToCompare.ToString() == sourcePropertyValue.objectReferenceValue.ToString();
                    }
                    else return sourcePropertyValue.objectReferenceValue != null; // By default, check if an object is assigned

                case SerializedPropertyType.Enum:
                    if (objToCompare != null && objToCompare is Enum)
                    {
                        string enumPropValue = sourcePropertyValue.enumNames.Length == 0 ? "undefined" : sourcePropertyValue.enumNames[sourcePropertyValue.enumValueIndex];
                        return objToCompare.ToString() == enumPropValue;
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);

                // OTHER PROPERTY TYPES

                case SerializedPropertyType.String:
                    if (objToCompare != null && objToCompare is String)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.stringValue;
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);

                case SerializedPropertyType.Integer:
                    if (objToCompare != null && objToCompare is int)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.intValue.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);

                case SerializedPropertyType.Float:
                    if (objToCompare != null && objToCompare is float)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.floatValue.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);  

                case SerializedPropertyType.Color:
                    if (objToCompare != null && objToCompare is Color)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.colorValue.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);              

                case SerializedPropertyType.LayerMask:
                    if (objToCompare != null && objToCompare is LayerMask)
                    {
                        LayerMask mask = (LayerMask)sourcePropertyValue.intValue;
                        return objToCompare.ToString() == mask.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);

                case SerializedPropertyType.Vector2:
                    if (objToCompare != null && objToCompare is Vector2)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.vector2Value.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);   

                case SerializedPropertyType.Vector3:
                    if (objToCompare != null && objToCompare is Vector3)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.vector3Value.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);   

                case SerializedPropertyType.Vector4:
                    if (objToCompare != null && objToCompare is Vector4)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.vector4Value.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);
                    
                case SerializedPropertyType.Rect:
                    if (objToCompare != null && objToCompare is Rect)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.rectValue.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);                  

                case SerializedPropertyType.ArraySize:
                    if (objToCompare != null)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.arraySize.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);
                    
                case SerializedPropertyType.Character:
                    if (objToCompare != null && objToCompare is char)
                    {
                        char charPropValue = (char)sourcePropertyValue.intValue;
                        return objToCompare.ToString() == charPropValue.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type); 

                case SerializedPropertyType.AnimationCurve:
                    if (objToCompare != null && objToCompare is AnimationCurve)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.animationCurveValue.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);

                case SerializedPropertyType.Bounds:
                    if (objToCompare != null && objToCompare is Bounds)
                    {
                        return objToCompare.ToString() == sourcePropertyValue.boundsValue.ToString();
                    }
                    else return NothingToCompareWith(sourcePropertyValue.type);       

                default:
                    Debug.LogError("Data type of the property used for conditional hiding [" + sourcePropertyValue.propertyType + "] is currently not supported");
                    return true;
            }
        }

        private bool NothingToCompareWith(string type)
        {
            Debug.LogError($"To use a {type} as condition you must specify a {type} to compare with, ensure you specified a {type} as objToCompare in the attribute constructor.");
            return true;
        }
    }
}
