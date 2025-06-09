using System;
using UnityEditor;
using UnityEngine;

namespace RS.Utilities.Editor
{
    [CustomPropertyDrawer(typeof(Timing))]
    public class TimingEditor : PropertyDrawer
    {
        // TODO: i'm not really sure this might be useful, don't commit it for now
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty frame = property.FindPropertyRelative("Frame");

            float seconds = Timing.FrameToSeconds(frame.intValue);

            Rect positionSeconds = position;
            positionSeconds.xMin = positionSeconds.xMax - position.width * 0.35f + 5;
            position.width = position.width * 0.65f;

            frame.intValue = EditorGUI.IntField(position, label, frame.intValue);

            float newSeconds =  EditorGUI.FloatField(positionSeconds, seconds);
            if(Math.Abs(seconds - newSeconds) > 0.0001f)
            {
                frame.intValue = Timing.SecondsToFrame(newSeconds);
            }
        }
    }
}
