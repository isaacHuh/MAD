using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    public float xRotation = 0f;

    float angRot;
    public float angMult = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        angMult = Mathf.Clamp(angMult,0,15f);
        angMult *= 0.999f;
        if(angMult < 0.2){
            angRot = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl))
        {
            return;
        }

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        angRot += Time.deltaTime;

        angRot %= (2 * Mathf.PI);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, angMult * Mathf.Sin(angRot)); // Mathf.Sin(angRot)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
