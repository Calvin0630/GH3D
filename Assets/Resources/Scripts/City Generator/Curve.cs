using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Curve : MonoBehaviour {
    public List<Vector3> controlPoints = new List<Vector3>();

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
            controlPoints.Add(controlPoints[controlPoints.Count - 1] + riverDir);
        }
    }
}
