using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Gravity : MonoBehaviour
{
    public CharacterController controller;

    public LayerMask colliders;
    
    public Transform ground;

    public float velocity = 0f;

    public bool grounded;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    //Update is called 100 times per second
    private void FixedUpdate()
    {
        controller.Move(Vector3.up * velocity);
        grounded = Physics.CheckSphere(ground.position, 0.2f, colliders);
        if (!grounded)
        {
            velocity -= (9.81f / 1000);
        } 
        else
        {
            velocity = 0f;
        }
    }

    public bool isGrounded() 
    {
        return grounded;
    }

    public void setVelocity (float velocity)
    {
        if (velocity > 0f)
        {
            this.velocity = velocity;
        } 
        else
        {
            this.velocity = 0f;
            Debug.Log("Don't add negative velocity on y-Axis unless it's gravitiy. Class:Gravity Line:59");
        }
    }
}
