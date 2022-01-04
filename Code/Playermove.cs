using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Playermove : MonoBehaviour 
{
    public CharacterController controller; 
    public float speed = 6f, gravity = 9.8f, jumpForce = 3f, groundDistance = 0.4f; 
    public Transform Groundcheck; 
    public LayerMask Raycast;
    bool isGrounded; 
    public int speedUp = 0, max = 1;
    Vector3 velocity; 
    void Update()
    {
        for (; speedUp >= max ; max++)
        {
            speed = speed + ((speed * 10) / 100);
        }
        isGrounded = Physics.CheckSphere(Groundcheck.position, groundDistance, Raycast); 
        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f; 
        }
        if(Input.GetKeyDown("space") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpForce * gravity); 
        }
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 
        Vector3 move = transform.right * x + transform.forward * z; 
        controller.Move(move * speed * Time.deltaTime); 
        velocity.y -= gravity * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime); 
    }
}