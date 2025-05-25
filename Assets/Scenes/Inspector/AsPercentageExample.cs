using RS.Utilities;
using UnityEngine;

namespace RS.Example
{
	public class AsPercentageExample : MonoBehaviour
	{
        [Header("Set the inspector to debug mode to check the actual value behind the slider")]

		[AsPercentage] // default 0 to 1 by default min and max value not shown in label
        public float default0To1;

		[AsPercentage(-125,432)] // custom with min and max defined by user, by default min and max value shown in label
        public float customMinMaxWithValues;

        [AsPercentage(-125, 432, false)] // custom with min and max defined by user, min and max value hidden in label
        public float customMinMaxWithoutValues;

    } 
}
