using System;
using UnityEngine;

namespace RS.Utilities
{
    // TODO: i'm not really sure this might be useful, don't commit it for now
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Timing : IComparable<Timing>
    {
        // TODO: This should be based on actual project target frame rate ?
        private const float FRAME_PER_SECONDS = 30f;

        public int Frame;

        public float Seconds
        {
            get { return FrameToSeconds(Frame); }
            set { Frame = SecondsToFrame(value); }
        }

        public static float FrameToSeconds(int frame)
        {
            return Mathf.Round(frame / FRAME_PER_SECONDS * 1000f) / 1000f;
        }

        public static int SecondsToFrame(float seconds)
        {
            return Mathf.RoundToInt(seconds * FRAME_PER_SECONDS);
        }

        public static implicit operator float(Timing timing)
        {
            return timing.Seconds;
        }

        public int CompareTo(Timing other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            return Frame.CompareTo(other.Frame);
        }
    } 
}

