using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    GameObject hookPrefab;
    GameObject hookInstance;
    LineRenderer lineRenderer;
    //for shooting hooks
    float triangulationDist = 10;
    //HookPoint contains a boolean (isActive) and a vector (position)
    HookPoint endOfRope = new HookPoint();
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(0);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire1") > 0.7f) {
            if (!endOfRope.isActive) {
                Vector3 directionOfShot = Camera.main.transform.forward;
                Debug.DrawRay(transform.position, directionOfShot, Color.green, 5000);
                /*
                hookInstance = (GameObject)Instantiate(hookPrefab, transform.position, Quaternion.identity);
                hookInstance.transform.LookAt(position);
                hookInstance.GetComponent<Rigidbody>().velocity = 100 * hookInstance.transform.forward;
                */
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionOfShot, out hit/*, Mathf.Infinity, LayerMask.NameToLayer("Environment")*/)) {
                    //do stuff
                    print(hit.point);
                    endOfRope.isActive = true;
                    endOfRope.position = hit.point;
                }
                endOfRope.isActive = true;
            }
        }
        else {
            endOfRope.isActive = false;
            lineRenderer.SetVertexCount(0);
        }

        if (endOfRope.isActive) {
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, endOfRope.position);
            GetComponent<Rigidbody>().AddForce(((Vector3)(endOfRope.position - transform.position)).normalized * 50);
        }
	}

    public static void SetHookContactPosition(Vector3 v) {

    }
}
