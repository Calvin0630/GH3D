using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
    public Vector3 positionRelativeToPlayer;
    public GameObject target;
    public float rotateSpeedX;
    public float rotateSpeedY ;
    Vector3 offset;
    Vector3 yRotation = Vector3.zero;
    float horizontal, vertical;

    void Start() {
        offset = -positionRelativeToPlayer;
    }

    void LateUpdate() {

        GetCameraDeltaController();
        target.transform.Rotate(0, horizontal, 0);
        yRotation += new Vector3(0,vertical,0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);
        
        transform.LookAt(target.transform.position + yRotation);
        
    }
    
    //gets necasary camera rotation from mouse
    void GetCameraDeltaMouse() {
        horizontal = Input.GetAxis("Mouse X") * rotateSpeedX;
        vertical = Input.GetAxis("Mouse Y") * rotateSpeedY;
    }

    //gets necasary camera rotation from controller
    void GetCameraDeltaController() {
        horizontal = Input.GetAxis("RStickX") * rotateSpeedX;
        vertical = Input.GetAxis("RStickY") * rotateSpeedY;
    }

}
