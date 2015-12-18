using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float walkSpeed;
    Vector3 input;
    Vector3 moveDir;
    Vector3 relativeMoveDir;
	// Use this for initialization
	void Start () {
        if (walkSpeed == 0) print("Warning walkSpeed == 0");
	}
	
	// Update is called once per frame
	void Update () {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDir = walkSpeed * Rotate(transform.forward, input.normalized);
        GetComponent<Rigidbody>().MovePosition(moveDir + transform.position);
	}

    //rotates vector a by vector b (relative to (0,0,1) on the x-z plane 
    Vector3 Rotate(Vector3 a, Vector3 b) {
        //gets the angle relative to (0,0,1) to the right is negative
        float angleOfRotation = -Mathf.Atan2(b.x, b.z);
        Vector3 result = Vector3.zero;
        if (b.magnitude > 0.5f) result = new Vector3(a.x*Mathf.Cos(angleOfRotation) - a.z*Mathf.Sin(angleOfRotation), a.y, a.x*Mathf.Sin(angleOfRotation) + a.z*Mathf.Cos(angleOfRotation));
        return result;
    }
}
