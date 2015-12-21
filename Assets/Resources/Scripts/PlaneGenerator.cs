using UnityEngine;
using System.Collections;

public class PlaneGenerator : MonoBehaviour {

    // Use this for initialization
    void Start() {
        GetComponent<MeshFilter>().mesh = CreateGround(10, 3);
    }

    // Update is called once per frame
    void Update() {

    }

    //creates a square mesh where segments is the number of squares along the top and side. Segments must be < 255
    public Mesh CreateGround(int size, int vertsPerWorldUnit = 1) {
        Mesh mesh = new Mesh();
        int segments = size * vertsPerWorldUnit;
        int numberOfSquares = (segments) * (segments);
        float vertDistance = 1 / (float)vertsPerWorldUnit;
        print("verDist: " + vertDistance);
        Vector3[] verts = new Vector3[(segments + 1) * (segments + 1)];
        Vector2[] uvs = new Vector2[(segments + 1) * (segments + 1)];
        int[] tris = new int[numberOfSquares * 6];
        //does vertices. example shows vert indices with segments == 4
        // 0 1 2 3 4
        // 5 6 7 8 9
        //...etc.
        for (int i = 0; i <= segments; i++) {
            for (int j = 0; j <= segments; j++) {
                //start at top left and goes to the right
                verts[i * (segments + 1) + j ] = new Vector3(j * vertDistance + -((float)size / 2), 0, ((float)size / 2) - i *vertDistance);
            }
        }
        //does tris
        int iterationIndex = 0;int verticeIndex = 0;
        for (int i = 0; i < segments; i++) {
            for (int j = 0; j < segments; j++) {
                verticeIndex = (segments+1) * i + j ;
                tris[(iterationIndex) * 6] = verticeIndex;
                tris[(iterationIndex) * 6 + 1] = verticeIndex + 1;
                tris[iterationIndex * 6 + 2] = verticeIndex + segments + 2;
                tris[iterationIndex * 6 + 3] = verticeIndex;
                tris[iterationIndex * 6 + 4] = verticeIndex + segments + 2;
                tris[iterationIndex * 6 + 5] = verticeIndex + segments + 1;
                iterationIndex++;
            }
        }
        //does uvs
        for(int i=0;i<=segments;i++) {
            for(int j=0;j<=segments;j++) {
                uvs[i * (segments + 1) + j] = new Vector2(i/segments, j/segments);
            }
        }
        mesh.vertices = verts;
        mesh.triangles = tris;
        mesh.uv = uvs;
        return mesh;
    }
}
