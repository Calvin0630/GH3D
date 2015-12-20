using UnityEngine;
using System.Collections;

public static class CityGenerator {
    public static void Generate() {

    }

    public static Vector3 BezierCurve(Vector3[] points, float t, int indexOffset) {
        if (points.Length < 3) throw new UnityException("Points array must have at least 3 elements");

        t = Mathf.Clamp(t, 0, 1f);

        int segments = (points.Length - 1) / 2;

        float segmentWidth = 1.0f / segments;
        if (t <= segmentWidth * (indexOffset + 1)) {
            t = (t % segmentWidth) / segmentWidth;
            float oneMinusT = 1.0f - t;
            int offset = indexOffset * 2;
            return oneMinusT * oneMinusT * points[0 + offset] + 2 * oneMinusT * t * points[1 + offset] + t * t * points[2 + offset];
        } else if (t <= 1.0f) {
            return BezierCurve(points, t, indexOffset + 1);
        } else {
            return Vector3.zero;
        }
    }
}
