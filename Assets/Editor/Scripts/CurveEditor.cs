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
    }

    void OnSceneGUI() {
        List<Vector3> controlPoints = targetComponent.controlPoints;
        int controlPointCount = controlPoints.Count;
        if(controlPointCount > 0) {
            if(lastPos == null) {
                lastPos = targetComponent.transform.position;
            }
            Vector3 deltaPos = targetComponent.transform.position - lastPos;
            lastPos = targetComponent.transform.position;
            for(int i = 0; i < controlPointCount; i += 4) {
                Handles.DrawBezier(
                    controlPoints[i],
                    controlPoints[i + 3],
                    controlPoints[i + 1],
                    controlPoints[i + 2],
                    curveColor,
                    new Texture2D(1, 2), // replace
                    curveWidth); // change to user defined
                Handles.color = controlPointColor;
                Handles.DrawLine(controlPoints[i], controlPoints[i + 1]);
                Handles.DrawLine(controlPoints[i + 3], controlPoints[i + 2]);
                for (int j = 0; j < 4; j++) {
                    controlPoints[i + j] = Handles.PositionHandle(controlPoints[i + j] + deltaPos, Quaternion.identity);
                    controlPoints[i + j] = new Vector3(controlPoints[i + j].x, targetComponent.transform.position.y, controlPoints[i + j].z);
                    Handles.color = controlPointColor;
                    Handles.SphereCap(i + j, controlPoints[i + j], Quaternion.identity, controlPointRadius);
                }
            }
        }
    }
}
