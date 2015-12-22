using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Curve))]
public class CurveEditor : Editor {
    Curve targetComponent;
    Vector3 lastPos;
    Color curveColor = Color.yellow;
    float curveWidth = 10.0f;
    Color controlPointColor = Color.red;
    Color controlPointSelectedColor = Color.blue;
    float controlPointRadius = 0.2f;

    void OnEnable() {
        targetComponent = (Curve)target;
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.LabelField("Curve", EditorStyles.boldLabel);
        curveColor = EditorGUILayout.ColorField("Color", curveColor);
        curveWidth = EditorGUILayout.FloatField("Width", curveWidth);
        EditorGUILayout.LabelField("Control Points", EditorStyles.boldLabel);
        controlPointColor = EditorGUILayout.ColorField("Color", controlPointColor);
        controlPointRadius = EditorGUILayout.FloatField("Radius", controlPointRadius);
        EditorGUILayout.LabelField("Controls", EditorStyles.boldLabel);
        if (GUILayout.Button("Add Segment")) {
            targetComponent.AddSegment();
        }
        if(GUILayout.Button("Remove Segment")) {
            targetComponent.RemoveSegment();
        }
    }

    void OnSceneGUI() {
        List<Vector3> controlPoints = targetComponent.controlPoints;
        int controlPointCount = controlPoints.Count;
        if (lastPos == null) {
            lastPos = targetComponent.transform.position;
        }
        Vector3 deltaPos = targetComponent.transform.position - lastPos;
        lastPos = targetComponent.transform.position;
        if (controlPointCount == 1) {
            UpdateHandle(controlPoints, 0, deltaPos);
        } else if (controlPointCount > 1) {
            for (int i = 0; i < controlPointCount - 3; i += 3) {
                Handles.DrawBezier(
                    controlPoints[i],
                    controlPoints[i + 3],
                    controlPoints[i + 1],
                    controlPoints[i + 2],
                    curveColor,
                    new Texture2D(1, 2), // replace!!!
                    curveWidth);
                Handles.color = controlPointColor;
                Handles.DrawLine(controlPoints[i], controlPoints[i + 1]);
                Handles.DrawLine(controlPoints[i + 3], controlPoints[i + 2]);
                UpdateHandle(controlPoints, 0, deltaPos);
                for (int j = 1; j < 4; j++) {
                    UpdateHandle(controlPoints, i + j, deltaPos);
                }
            }
        }
    }

    void UpdateHandle(List<Vector3> controlPoints, int index, Vector3 deltaPos) {
        controlPoints[index] = Handles.PositionHandle(controlPoints[index] + deltaPos, Quaternion.identity);
        controlPoints[index] = new Vector3(controlPoints[index].x, targetComponent.transform.position.y, controlPoints[index].z);
        Handles.color = controlPointColor;
        Handles.SphereCap(index, controlPoints[index], Quaternion.identity, controlPointRadius);
    }
}
