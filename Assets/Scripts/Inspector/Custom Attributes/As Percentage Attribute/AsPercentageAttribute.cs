using System;
using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// Draw a float value as a percentage slider
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AsPercentageAttribute : PropertyAttribute
    {
        /// <summary>
        /// Minimum value of the float, correspond to when the slider is at 0.
        /// </summary>
        public float Min;

        /// <summary>
        /// Maximum value of the float, correspond to when the slider is at 100.
        /// </summary>
        public float Max;

        /// <summary>
        /// Should we show the min and max in the label.
        /// </summary>
        public bool ShowMinMax;

        /// <summary>
        /// Draw a float value as a percentage slider, the float value goes from 0 to 1.
        /// </summary>
        public AsPercentageAttribute()
        {
            Min = 0;
            Max = 1;
            ShowMinMax = false;
        }

        /// <summary>
        /// Draw a float value as a percentage slider, you define the min and max for the float value.
        /// </summary>
        /// <param name="min">Minimum value of the float, when the slider is at 0</param>
        /// <param name="max">Maximum value of the float, when the slider is at 100</param>
        /// <param name="showMinMax">Should we display the actual min and max in the label</param>
        public AsPercentageAttribute(float min, float max, bool showMinMax = true)
        {
            this.Min = min;
            this.Max = max;
            this.ShowMinMax = showMinMax;
        }
    } 
}
