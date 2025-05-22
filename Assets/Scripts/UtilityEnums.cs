using UnityEngine;

namespace RS.Utilities
{
    /// <summary>
    /// Represent the 3 standard axis of a unity 3D scene: X, Y and Z.
    /// </summary>
    public enum Axis
    {
        X,
        Y,
        Z
    }

    /// <summary>
    /// Represent different types of curve
    /// </summary>
    public enum CurveType
    {
        Sqrt = 0,
        FakeSqrt = 1,
        Linear = 2,
        Squared = 3,
        Cubed = 4,
        Parabola = 5,
        SmoothLinear = 6,
        SmoothEnd = 7,

        SquaredEaseOut = 8,
        CubedEaseOut = 9,
    }

    /// <summary>
    /// Represent different types of time
    /// </summary>
    public enum TimeType
    {
        Normal,
        Fixed,
        Unscaled,
    }
}