using UnityEngine;
using System.Collections;

public static class Helper {

    public static Vector2 CubicBezier(Vector2[] controlPoints, float t)
    {
        if (controlPoints.Length < 4) throw new UnityException("Points array must have at least 4 elements");

        t = Mathf.Max(0, t);

        if (t <= 1.0f)
        {
            float oneMinusT = 1f - t;
            Vector2 term1 = oneMinusT * oneMinusT * oneMinusT * controlPoints[0];
            Vector2 term2 = 3f * oneMinusT * oneMinusT * t * controlPoints[1];
            Vector2 term3 = 3f * oneMinusT * t * t * controlPoints[2];
            Vector2 term4 = t * t * t * controlPoints[3];

            return term1 + term2 + term3 + term4;
        }
        else if (controlPoints.Length - 4 >= 4)
        {
            Vector2[] nextControlPoints = new Vector2[controlPoints.Length - 4];
            for (int i = 0; i < nextControlPoints.Length; i++)
            {
                nextControlPoints[i] = controlPoints[4 + i];
            }
            return CubicBezier(nextControlPoints, t - 1.0f);
        }
        else
        {
            return CubicBezier(controlPoints, 1.0f);
        }
        
    }

    public static  bool IsPowerOfTwo(int x)
    {
        return (x != 0) && ((x & (x - 1)) == 0);
    }
}
