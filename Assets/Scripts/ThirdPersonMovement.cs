using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]                             //To run this code, the object needs to have a CharacterController attached.

/// <summary>
/// This script gives the the object its applied to the ability to be controlled by the player.
/// </summary>
public class ThirdPersonMovement : MonoBehaviour {
    /// <summary>
    /// Stores the pawn that the player moves as the Character.
    /// </summary>
    CharacterController pawn;
    /// <summary>
    /// Stores the OrbitalCamera that is following the player.
    /// </summary>
    public OrbitalCamera orbitCam;

    /// <summary>
    /// The speed the player travels at, measured in meters.
    /// </summary>
    public float speed = 6.0f;
    /// <summary>
    /// The speed the player initially starts at when jumping into the air.
    /// </summary>
    public float jumpSpeed = 60.0f;
    /// <summary>
    /// The force applied on the player when jumping or falling.
    /// </summary>
    public float gravity = 60.0f;

    /// <summary>
    /// Stores the direction the player is moving in.
    /// </summary>
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start () {
        pawn = GetComponent<CharacterController>();                                 //Stores the CharacterController of the object this script is applied to as "pawn".
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveAround();                                                               //Calls upon the MoveAround() function. 
        
    }

    // Handles all the player's movement on the ground.
    private void MoveAround()
    {
        if (pawn.isGrounded)
        {
            //We are grounded, so apply movement.
            //You get the direction directly from the axis.


            float h = Input.GetAxis("Horizontal");                      //Stores the Horizontal Input of the keyboard to be referenced within MoveAround.
            float v = Input.GetAxis("Vertical");                        //Stores the Vertical Input of the keyboard to be referenced within MoveAround.

            if (h != 0 || v != 0)
            {
                float camYaw = orbitCam.transform.localEulerAngles.y;   //Stores the Yaw of the OrbitalCamera.
                transform.eulerAngles = new Vector3(0, camYaw, 0);      //Adjusts the rotation of this object using Euler Angles.
            }

            moveDirection = transform.TransformDirection(new Vector3(-h, 0.0f, -v)) * speed;         //Get the direction the player is going to move based on the direction it's facing, the "Horizontal" and "Vertical" Inputs, and it's speed.

            if (Input.GetButton("Jump"))                                                            //if the "Jump" input is pressed, AND the player is jumping...            
            {
                moveDirection.y += jumpSpeed;                                                           //Add the player's jump speed moveDirection to control air movement.
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;                //Apply gravity.
        pawn.Move(moveDirection * Time.deltaTime);                  //Move the controller.
    }
}
