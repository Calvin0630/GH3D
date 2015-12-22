﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Curve : MonoBehaviour {
    public List<Vector3> controlPoints = new List<Vector3>();

    void Start() {
        AddSegment();
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    public void AddSegment() {
        int points = controlPoints.Count;
        Vector3 riverDir = Vector3.forward;
        Vector3 riverEndPos = Vector3.zero;
        if (points > 0) {
            riverDir = (controlPoints[points - 1] - controlPoints[points - 2]).normalized;
            riverEndPos = controlPoints[points - 1];
        }
        if (points == 0) {
            controlPoints.Add(transform.position + transform.forward);
        }
        // add 3 more control points to control points list
        for(int i = 1; i < 4; i++) {
            controlPoints.Add(riverEndPos + riverDir * i);
        }
    }
}
