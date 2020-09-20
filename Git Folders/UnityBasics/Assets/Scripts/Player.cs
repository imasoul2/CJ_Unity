using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;  // for scoreboard


// Declaring namespaces
// telling unity what namespace to use 
public class Player : MonoBehaviour  // OOP, named the class name as the name of the script by default.
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform groundCheckTransform = null; // shown in the inspector
    // declaring variables
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private int superJumpsRemaining;
    private bool isGrounded;
    // static keyword makes this variable a Member of the class, not any instasnce
    public static int coinScore;







    // Start is called before the first frame update
    void Start() // will get called first
    {
        // store the value 
    
        rigidbodyComponent = GetComponent<Rigidbody>();
        coinScore = 0;

    }

    // Update is called once per frame, execute this method per every frame.
    // framerate will depend on how the game is configured. 
    void Update()
    {
     

        // this will occur only when the key is down at that instance
        if (Input.GetKeyDown(KeyCode.Space)) // if the space key is down,
        {
            jumpKeyWasPressed = true;
        }

        // Axis = float type  - for left + for right
        horizontalInput = Input.GetAxis("Horizontal"); // check the project setting

    }
    // fixed update is called once every physics update  
    // physic engine will still update at 100Hz
    private void FixedUpdate()
    {
        // this part runs in sequence
        
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
        // horizontal , up down, forward backwrad, remain the y component


        // player alwAYS collides itself  (ground of the player),
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        // key press, stroke will be not good to be placed here, it could miss them
        if (jumpKeyWasPressed) // if the space key is down,
        {
            float jumpPower = 6f;
            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;

        }

       


    }

 
    // Registers collisions but it does not react physically.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
            coinScore++;
        }
    }


}



