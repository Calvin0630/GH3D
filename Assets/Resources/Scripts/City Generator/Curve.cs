using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Curve : MonoBehaviour {
    public List<Vector3> controlPoints = new List<Vector3>();
    public Color curveColor = new Color(0, 128f / 255f, 1f);
    public float curveWidth = 12.0f;
    public Color controlPointColor = Color.white;
    public float controlPointSize = 1.0f;

    void Start() {
        AddSegment();
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
    }

    public void AddSegment() {
        int points = controlPoints.Count;
        Vector3 riverDir = Vector3.forward;
        if (points > 1) {
            riverDir = (controlPoints[points - 1] - controlPoints[points - 2]).normalized;
        }
        if (points == 0) {
            controlPoints.Add(transform.position + transform.forward);
        }
        // add 3 more control points to control points list
        for(int i = 0; i < 3; i++) {
            controlPoints.Add(controlPoints[controlPoints.Count - 1] + riverDir * 10f);
        }
    }

    public void RemoveSegment() {
        if(controlPoints.Count > 1) {
            controlPoints.RemoveRange(controlPoints.Count - 3, 3);
        }
    }
}
