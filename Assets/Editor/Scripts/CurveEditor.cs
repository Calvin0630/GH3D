using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Curve))]
public class CurveEditor : Editor {
    Curve targetComp;
    Vector3 lastPos;

    void OnEnable() {
        targetComp = (Curve)target;
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.LabelField("Curve", EditorStyles.boldLabel);
        targetComp.curveColor = EditorGUILayout.ColorField("Color", targetComp.curveColor);
        targetComp.curveWidth = EditorGUILayout.FloatField("Width", targetComp.curveWidth);
        EditorGUILayout.LabelField("Control Points", EditorStyles.boldLabel);
        targetComp.controlPointColor = EditorGUILayout.ColorField("Color", targetComp.controlPointColor);
        targetComp.controlPointSize = EditorGUILayout.FloatField("Size", targetComp.controlPointSize);
        EditorGUILayout.LabelField("Controls", EditorStyles.boldLabel);
        if (GUILayout.Button("Add Segment")) {
            targetComp.AddSegment();
        }
        if(GUILayout.Button("Remove Segment")) {
            targetComp.RemoveSegment();
        }
    }

    void OnSceneGUI() {
        List<Vector3> controlPoints = targetComp.controlPoints;
        int controlPointCount = controlPoints.Count;
        if (lastPos == null) {
            lastPos = targetComp.transform.position;
        }
        Vector3 deltaPos = targetComp.transform.position - lastPos;
        lastPos = targetComp.transform.position;
        if (controlPointCount == 1) {
            UpdateHandle(controlPoints, 0, deltaPos);
        } else if (controlPointCount > 1) {
            for (int i = 0; i < controlPointCount - 3; i += 3) {
                Handles.DrawBezier(
                    controlPoints[i],
                    controlPoints[i + 3],
                    controlPoints[i + 1],
                    controlPoints[i + 2],
                    targetComp.curveColor,
                    new Texture2D(1, 2), // replace!!!
                    targetComp.curveWidth);
                Handles.color = targetComp.controlPointColor;
                Handles.DrawLine(controlPoints[i], controlPoints[i + 1]);
                Handles.DrawLine(controlPoints[i + 3], controlPoints[i + 2]);
                for (int j = 1; j < 4; j++) {
                    UpdateHandle(controlPoints, i + j, deltaPos);
                }
            }
            UpdateHandle(controlPoints, 0, deltaPos);
        }
    }

    void UpdateHandle(List<Vector3> controlPoints, int index, Vector3 deltaPos) {
        controlPoints[index] = Handles.PositionHandle(controlPoints[index] + deltaPos, Quaternion.identity);
        controlPoints[index] = new Vector3(controlPoints[index].x, targetComp.transform.position.y, controlPoints[index].z);
        Handles.color = targetComp.controlPointColor;
        Handles.SphereCap(index, controlPoints[index], Quaternion.identity, targetComp.controlPointSize);
    }
}
