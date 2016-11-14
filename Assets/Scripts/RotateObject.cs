using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

    public float RotSpeed = 10;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * RotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * RotSpeed * Mathf.Deg2Rad;

        //transform.RotateAround(Vector3.up, -rotX);
        //transform.RotateAround(Vector3.right, rotY);
        transform.Rotate(Vector3.up, -rotX * 40, Space.World);
        transform.Rotate(Vector3.right, rotY * 40, Space.World);
    }
}
