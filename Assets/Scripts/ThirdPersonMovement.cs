using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]                             //To run this code, the object needs to have a CharacterController attached.
[RequireComponent(typeof(Camera))]                                          //To run this code, the object needs to have a Camera attached.
public class ThirdPersonMovement : MonoBehaviour {
    /// <summary>
    /// Stores the pawn that the player moves as the Character.
    /// </summary>
    CharacterController pawn;
    /// <summary>
    /// Stores the camera the player will orient itself to.
    /// </summary>
    Camera cam;

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
        cam = GetComponentInChildren<Camera>();                                     //Stores the Camera child of the object this script is applied to as "cam".
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveAround();                                                               //Calls upon the MoveAround() function. 
        if(Input.GetButton("Fire1")) Shoot();                                       //If the player presses the 'Fire1' button, call upon Shoot()
        
    }

    //LateUpdate is called once per frame, after every object has updated.
    private void LateUpdate()
    {
        TurnAround();
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
    private void TurnAround()
    {
        //pawn.transform.localEulerAngles = new Vector3(cam.transform.localPosition.y, cam.transform.localPosition.x, 0.0f);
    }

    //Is called upon when the player needs to shoot.
    private void Shoot()
    {
        print("Player is shooting");
    }
}
