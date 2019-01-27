using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float minimumX = -60f;
    public float maximumX = 60f;
    public float minimumY = -360f;
    public float maximumY = 360f;

    public float sensitivityX = 15f;
    public float sensitivityY = 1000f;

    private Camera cam;

    float rotationY = 0f;
    float rotationX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        rotationY = Input.GetAxis("Mouse Y") * sensitivityY*Time.deltaTime;
        rotationX = Input.GetAxis("Mouse X") * sensitivityX*Time.deltaTime;

        // rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        //transform.rotation *= Quaternion.Euler(transform.right * rotationY);
        transform.Rotate(Vector3.right, rotationY);

        transform.parent.rotation *= Quaternion.Euler(transform.parent.up * rotationX);
    }
}