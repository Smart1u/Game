using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class camera : MonoBehaviour
{
    public float mouseSens = 100f; 
    public Transform playerBody;
    float xRotation = 0f; 
    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
    void Update() 
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens ; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens ; 

        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // зажимает камеру от -90 до 90 градусов

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
        playerBody.Rotate(Vector3.up * mouseX); // Тело игрока будет поворачивать вместе с камерой 
    }
}
