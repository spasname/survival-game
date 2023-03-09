using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    
    public Transform playerBody; //includes Head
    public Transform playerHead;

    private float mouseX = 0f;
    private float mouseY = 0f;

    private float headRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; 
    }

    private void FixedUpdate()
    {
        playerBody.Rotate(new Vector3 (0, mouseX , 0));
        rotateHead();
    }

    private void rotateHead()
    {
        headRotation -= mouseY;
        headRotation = Mathf.Clamp(headRotation, -40f, 40f);
        playerHead.localRotation = Quaternion.Euler(headRotation, 0f, 0f);
    }
}
