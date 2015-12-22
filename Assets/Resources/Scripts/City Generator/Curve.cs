using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Curve : MonoBehaviour {
    public List<GameObject> controlPoints = new List<GameObject>();

    void Start() {
        AddSegment();
    }

    public void AddSegment() {
        int points = controlPoints.Count;
        Vector3 riverDir = Vector3.forward;
        Vector3 riverEndPos = Vector3.zero;
        if (points > 0) {
            riverDir = (controlPoints[points - 1].transform.position - controlPoints[points - 2].transform.position).normalized;
            riverEndPos = controlPoints[points - 1].transform.position;
        }
        if (points == 0) {
            AddControlPoint();
        }
        // add 3 more control points to control points list
        for(int i = 0; i < 3; i++) {
            GameObject controlPoint = AddControlPoint();
            Vector3 pos = riverEndPos + riverDir + new Vector3(0, 0, i);
            controlPoint.transform.position = pos;
        }
    }

    GameObject AddControlPoint() {
        GameObject controlPoint = new GameObject("Control Point");
        controlPoint.transform.SetParent(transform);
        controlPoint.AddComponent<CurveControlPoint>();
        controlPoints.Add(controlPoint);
        return controlPoint;
    }
}
