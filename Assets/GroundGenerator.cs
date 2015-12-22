using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour {
    GameObject planePrefab;
    public int citySize;
    public int sizeOfPlanes;
    public int defaultVertDensity;
    //a 2d array that hold references to all of the plane objects
    public static GameObject[,] ground;

    
	// Use this for initialization
	void Start () {
        ground = new GameObject[citySize/sizeOfPlanes, citySize / sizeOfPlanes];
        planePrefab = (GameObject) Resources.Load("Prefabs/Plane");
        GenerateGround();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GenerateGround() {
        Vector3 spawnPos;
        //start at top left and go right
        for (int i=0;i<citySize/sizeOfPlanes;i++) {
            for (int j = 0;j < citySize / sizeOfPlanes; j++) {
                spawnPos = new Vector3(-citySize/2 + (j+1) * sizeOfPlanes, 0, citySize/2 -(i+1) *sizeOfPlanes);
                ground[i, j] = (GameObject)Instantiate(planePrefab, spawnPos, Quaternion.identity);
                ground[i, j].GetComponent<Plane>().size = sizeOfPlanes;
                ground[i, j].GetComponent<Plane>().verticeDensity = defaultVertDensity;
                ground[i, j].GetComponent<Plane>().CreateMesh();
                ground[i, j].name = "Plane(" + i + " , " + j + ")";
            }
        }
    }

    public void GenerateWater() {

    }
}
