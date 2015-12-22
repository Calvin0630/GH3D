using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CityGenerator : EditorWindow {
    static GameObject riverPrefab;
    // Settings
    Vector3 cityCenter;
    float citySize = 256.0f;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/City Generator")]
    public static void Init() {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(CityGenerator));
    }

    // GUI elements are defined here
    void OnGUI() {
        titleContent = new GUIContent("City Generator");
        // OPTIONS
        EditorGUILayout.LabelField("Options", EditorStyles.boldLabel);
            cityCenter = EditorGUILayout.Vector3Field("City Center", cityCenter);
            citySize = EditorGUILayout.FloatField("City Size", citySize);
        // CONTROLS
        EditorGUILayout.LabelField("Controls", EditorStyles.boldLabel);
            if(GUILayout.Button("Add River")) {
                AddRiver();
            }
            if(GUILayout.Button("Generate City")) {
                GenerateCity();
            }
    }

    void AddRiver() {
        GameObject river = new GameObject("River");
        river.AddComponent<Curve>();
    }

    void GenerateCity() {
        PropertyQuadTree lots = new PropertyQuadTree(0, cityCenter, citySize);
    }
}
