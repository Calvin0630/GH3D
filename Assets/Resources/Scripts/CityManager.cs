using UnityEngine;
using System.Collections;

public class CityManager : MonoBehaviour {
    //renders in a square around the player with side length 2*renderdistance
    public float renderDistance;
    GameObject tilePrefab;
    float groundTileWidth;
    int tilesPerEdge;
    GameObject tileInstance;
    GameObject player;

	// Use this for initialization
	void Start () {
        tilePrefab = (GameObject)Resources.Load("Prefabs/Ground");
        groundTileWidth = tilePrefab.transform.localScale.x*10;
        tilesPerEdge =(int) (renderDistance / groundTileWidth);
        print("float: " + 2 * renderDistance / groundTileWidth);
        print(tilesPerEdge);
        player = GameObject.Find("Player");
        GenerateGround();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //creates all ground within render distance
    void GenerateGround() {
        for(int i=-tilesPerEdge/2;i<= tilesPerEdge/2;i++) {
            for (int j=-tilesPerEdge/2; j<=tilesPerEdge/2; j++) {
                tileInstance = (GameObject)Instantiate(tilePrefab, new Vector3(i*groundTileWidth, 0, j*groundTileWidth), Quaternion.identity);
            }
        }
    }

    void GenerateGroundAroundPerimeter() {

    }
}
