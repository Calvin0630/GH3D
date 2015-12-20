using UnityEngine;
using System.Collections;

public static class Helper {

    public static Vector2 BezierCurve(Vector2[] controlPoints, float t, int indexOffset)
    { // this will be rewritten to use 4 control points instead of 3
        if (controlPoints.Length < 3) throw new UnityException("Points array must have at least 3 elements");

        t = Mathf.Clamp(t, 0, 1f);

        int segments = (controlPoints.Length - 1) / 2;

        float segmentWidth = 1.0f / segments;
        if (t <= segmentWidth * (indexOffset + 1))
        {
            t = (t % segmentWidth) / segmentWidth;
            float oneMinusT = 1.0f - t;
            int offset = indexOffset * 2;
            return oneMinusT * oneMinusT * controlPoints[0 + offset] + 2 * oneMinusT * t * controlPoints[1 + offset] + t * t * controlPoints[2 + offset];
        }
        else if (t <= 1.0f)
        {
            return BezierCurve(controlPoints, t, indexOffset + 1);
        }
        else
        {
            return Vector2.zero;
        }
    }
}
