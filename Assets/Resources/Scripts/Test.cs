using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
    float x = 0;
    public Vector3[] points;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = CityGenerator.BezierCurve(points, x, 0);
        x += 0.005f;
    }
}
