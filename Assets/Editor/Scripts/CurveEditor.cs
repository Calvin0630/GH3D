using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Curve))]
public class CurveEditor : Editor {
    Curve targetComponent;
    void OnEnable() {
        targetComponent = (Curve)target;
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        if(GUILayout.Button("Add Segment")) {
            targetComponent.AddSegment();
        }
    }
}
