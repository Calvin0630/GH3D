using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CityGenerator : EditorWindow
{
    int minCitySize = 2;
    int maxCitySize = 2048;
    // Settings
    Vector3 cityCenter;
    int citySize;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/City Generator")]

    // when window is opened
    public static void ShowWindow ()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(CityGenerator));
    }

    // Use this for initialization
    void Init()
    {

    }

    // GUI elements are defined here
    void OnGUI ()
    {
        titleContent = new GUIContent("City Generator");
        // SETTINGS
        EditorGUILayout.LabelField("Settings", EditorStyles.boldLabel);
            cityCenter = EditorGUILayout.Vector3Field("City Center", cityCenter);
            citySize = EditorGUILayout.IntSlider("City Size", citySize, minCitySize, maxCitySize);
        // CONTROLS
        EditorGUILayout.LabelField("Controls", EditorStyles.boldLabel);
            if (GUILayout.Button("Generate"))
            {
                GenerateCity();
            }
    }

    void GenerateCity()
    {
        PropertyQuadTree lots = new PropertyQuadTree(0, cityCenter, citySize);
    }
}
