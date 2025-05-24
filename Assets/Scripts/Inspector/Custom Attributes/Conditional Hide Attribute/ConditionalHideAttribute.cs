using System;
using UnityEngine;

//Original version of the ConditionalHideAttribute created by Brecht Lecluyse (www.brechtos.com)
// See https://www.brechtos.com/hiding-or-disabling-inspector-properties-using-propertydrawers-within-unity-5/
//Modified by: Romain Sepulchre

namespace RS.Utilities
{
    /// <summary>
    /// An attribute that allows to hide or disable some fields in the inspector depending on a condition
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public class ConditionalHideAttribute : PropertyAttribute
    {
        /// <summary>
        /// The name of the field that will act as condition (field can be a bool or an object reference)
        /// </summary>
        public string ConditionalSourceField = "";

        /// <summary>
        /// An array of field names that will act as conditions, allow to have more than one condition (fields can be a bool or an object reference)
        /// </summary>
        public string[] ConditionalSourceFields = new string[] { };

        /// <summary>
        /// An array of field names that will act as conditions, allow to have more than one condition (fields can be a bool or an object reference)
        /// </summary>
        public object[] ConditionalSourceFieldsObjsToCompare = new object[] { };

        /// <summary>
        /// An array of bool that match entries in <i>ConditionalSourceFields</i> to tell if the condition must be inverted or not
        /// </summary>
        public bool[] ConditionalSourceFieldInverseBools = new bool[] { };

        /// <summary>
        /// Hide fields when true and disable fields when false
        /// </summary>
        public bool HideInInspector = false;

        /// <summary>
        /// Should we inverse the condition (hide/disable when the condition is met)
        /// </summary>
        public bool Inverse = false;

        /// <summary>
        /// Should use OR logic instead of AND logic when having multiple conditions.
        /// To use this parameter you must override <i>UseOrLogic</i> in the attribute declaration.
        /// (Ex: [ConditionalHide(new string[] { nameof(ConditionA), nameof(ConditionB) }, UseOrLogic = true)]).
        /// </summary>
        public bool UseOrLogic = false;

        /// <summary>
        /// An object to compare with the confition field 
        /// </summary>
        public object ObjToCompare = null;

        /// <summary>
        /// Hide or disable the field when the condition isn't met depending on <i>hideInInspector</i> parameter.
        /// Condition can be inverted using <i>inverse</i> parameter.
        /// </summary>
        /// <param name="conditionalSourceField">The name of the field that will act as condition (field can only be a bool or an object reference)</param>
        /// <param name="hideInInspector">Should we hide or disable the field</param>
        /// <param name="inverse">Should we inverse the condition</param>
        public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector=false, bool inverse = false)
        {
            this.ConditionalSourceField = conditionalSourceField;
            this.HideInInspector = hideInInspector;
            this.Inverse = inverse;
        }

        /// <summary>
        /// Hide or disable the field when the condition isn't met depending on <i>hideInInspector</i> parameter.
        /// Using <i>'objToCompare'</i> let you compare the value of the condition field with an object, this allows you to use other types field than bool and object reference
        /// (this is especially useful to use an Enum value as condition).
        /// </summary>
        /// <param name="conditionalSourceField">The name of the field that will act as condition (field type can be almost anything but type must match <i>'objToCompare'</i> type)</param>
        /// <param name="objToCompare">Object to compare with the field value</param>
        /// <param name="hideInInspector">Should we hide or disable the field</param>
        /// <param name="inverse">Should we inverse the condition</param>
        public ConditionalHideAttribute(string conditionalSourceField, object objToCompare, bool hideInInspector = false, bool inverse = false)
        {
            this.ConditionalSourceField = conditionalSourceField;
            this.ObjToCompare = objToCompare;
            this.HideInInspector = hideInInspector;
            this.Inverse = inverse;
            
        }

        /// <summary>
        /// Hide or disable the field depending on <i>hideInInspector</i> parameter, when using this constructor you must at least override <i>ConditionalSourceField</i> in the attribute declaration.
        /// (Ex: [ConditionalHide(true, ConditionalSourceField = nameof(Condition))]).
        /// </summary>
        /// <param name="hideInInspector">Should we hide or disable the field</param>
        public ConditionalHideAttribute(bool hideInInspector = false)
        {
            this.ConditionalSourceField = "";
            this.HideInInspector = hideInInspector;
            this.Inverse = false;
        }

        /// <summary>
        /// Hide or disable the field when the conditions aren't met depending on <i>hideInInspector</i> parameter (allow to use as many condition as needed).
        /// Conditions can be inverted using <i>inverse</i> parameter.
        /// </summary>
        /// <param name="conditionalSourceFields">An array of field names that will act as conditions (fields can only be bool or object reference)</param>
        /// <param name="hideInInspector">Should we hide or disable the field</param>
        /// <param name="inverse">Should we inverse the condition</param>
        public ConditionalHideAttribute(string[] conditionalSourceFields, bool hideInInspector = false, bool inverse = false)
        {
            this.ConditionalSourceFields = conditionalSourceFields;
            this.HideInInspector = hideInInspector;
            this.Inverse = inverse;
        }

        /// <summary>
        /// Hide or disable the field when the conditions aren't met depending on <i>hideInInspector</i> parameter (allow to use as many condition as needed).
        /// Each conditions can be inverted separetely by setting the bool at the matching index in <i>conditionalSourceFieldInverseBools</i>.
        /// Using <i>inverse</i> here invert the final condition after <i>conditionalSourceFieldInverseBools</i> has been considered.
        /// </summary>
        /// <param name="conditionalSourceFields">An array of field names that will act as conditions (fields can be a bool or an object reference)</param>
        /// <param name="conditionalSourceFieldInverseBools">An array of bool that match entries in <i>ConditionalSourceFields</i> to tell if the condition must be inverted or not</param>
        /// <param name="hideInInspector">Should we hide or disable the field</param>
        /// <param name="inverse">Should we inverse the result condition. Invert the final result after <i>conditionalSourceFieldInverseBools</i> has been considered</param>
        public ConditionalHideAttribute(string[] conditionalSourceFields, bool[] conditionalSourceFieldInverseBools, bool hideInInspector = false, bool inverse = false)
        {
            this.ConditionalSourceFields = conditionalSourceFields;
            this.ConditionalSourceFieldInverseBools = conditionalSourceFieldInverseBools;
            this.HideInInspector = hideInInspector;
            this.Inverse = inverse;
        }


        /// <summary>
        /// Hide or disable the field when the conditions aren't met depending on <i>hideInInspector</i> parameter (allow to use as many condition as needed).
        /// Each field value can be compared with its own compare object by setting the object at the matching index in <i>conditionalSourceObjsToCompare</i>.
        /// This allows you to use other types field than bool and object reference but field type must always match the type of the object to compare (For bool and ObjectReference default behaviour use null).
        /// </summary>
        /// <param name="conditionalSourceFields">An array of field names that will act as conditions (field type can be almost anything but type must match the type of the object to compare)</param>
        /// <param name="conditionalSourceObjsToCompare">An array of object that match entries in <i>ConditionalSourceFields</i> to compare with the field value</param>
        /// <param name="hideInInspector">Should we hide or disable the field</param>
        /// <param name="inverse">Should we inverse the condition</param>
        public ConditionalHideAttribute(string[] conditionalSourceFields, object[] conditionalSourceObjsToCompare, bool hideInInspector = false, bool inverse = false)
        {
            this.ConditionalSourceFields = conditionalSourceFields;
            this.ConditionalSourceFieldsObjsToCompare = conditionalSourceObjsToCompare;
            this.HideInInspector = hideInInspector;
            this.Inverse = inverse;
        }

        /// <summary>
        /// Hide or disable the field when the conditions aren't met depending on <i>hideInInspector</i> parameter (allow to use as many condition as needed).
        /// Each field value can be compared with its own compare object by setting the object at the matching index in <i>conditionalSourceObjsToCompare</i>.
        /// This allows you to use other types field than bool and object reference but field type must always match the type of the object to compare (For bool and ObjectReference default behaviour use null).
        /// Each conditions can be inverted separetely by setting the bool at the matching index in <i>conditionalSourceFieldInverseBools</i>.
        /// Using <i>inverse</i> here invert the final condition after <i>conditionalSourceFieldInverseBools</i> has been considered.
        /// </summary>
        /// <param name="conditionalSourceFields">An array of field names that will act as conditions (field type can be almost anything but type must match the type of the object to compare)</param>
        /// <param name="conditionalSourceObjsToCompare">An array of object that match entries in <i>ConditionalSourceFields</i> to compare with the field value</param>
        /// <param name="conditionalSourceFieldInverseBools">An array of bool that match entries in <i>ConditionalSourceFields</i> to tell if the condition must be inverted or not</param>
        /// <param name="hideInInspector">Should we hide or disable the field</param>
        /// <param name="inverse">Should we inverse the result condition. Invert the final result after <i>conditionalSourceFieldInverseBools</i> has been considered</param>
        public ConditionalHideAttribute(string[] conditionalSourceFields, object[] conditionalSourceObjsToCompare, bool[] conditionalSourceFieldInverseBools,  bool hideInInspector = false, bool inverse = false)
        {
            this.ConditionalSourceFields = conditionalSourceFields;
            this.ConditionalSourceFieldsObjsToCompare = conditionalSourceObjsToCompare;
            this.ConditionalSourceFieldInverseBools = conditionalSourceFieldInverseBools;
            this.HideInInspector = hideInInspector;
            this.Inverse = inverse;
        }
    } 
}
