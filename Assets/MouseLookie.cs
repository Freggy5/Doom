using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookie : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    public Transform body;

    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float moseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float moseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation = yRotation - moseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        body.Rotate(Vector3.up * moseX);
    }
}
