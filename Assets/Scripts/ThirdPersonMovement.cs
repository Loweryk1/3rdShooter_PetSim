using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMovement : MonoBehaviour {
    /// <summary>
    /// Stores the pawn that the player moves as the Character.
    /// </summary>
    CharacterController pawn;

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
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));              //Create a vector3 to store the player's movement. It then grabs the horizontal and vertical Input data to control "ground" movement.
            moveDirection *= speed;                                                                                         //Apply the player's speed to moveDirection.

            if (Input.GetButton("Jump"))                                 //if the "Jump" input is pressed, AND the player is jumping...            
            {
                moveDirection.y += jumpSpeed;                               //Add the player's jump speed moveDirection to control air movement.
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;                //Apply gravity.

        pawn.Move(moveDirection * Time.deltaTime);                  //Move the controller.
    }

    // [TODO:] possible means of aiming player?
    private void AimPlayer()
    {

    }
}
