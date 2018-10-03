using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonMovement : MonoBehaviour {
    /// <summary>
    /// Stores the pawn that the player moves as the Character.
    /// </summary>
    CharacterController pawn;

    /// <summary>
    /// The speed the player travels at, measured in meters.
    /// </summary>
    public float speed = 5;

	// Use this for initialization
	void Start () {
        pawn = GetComponent<CharacterController>(); //Stores the CharacterController of the object this script is applied to as "pawn".
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveAround();                               //Calls upon the MoveAround() function. 
        
    }

    // Handles all the player's movement on the ground.
    private void MoveAround()
    {
        float v = Input.GetAxis("Vertical");        //Stores the "Vertical" input for the player.
        float h = Input.GetAxis("Horizontal");      //Stores the "Horizontal" input for the player.

        Vector3 velocity = Vector3.zero;            //Initialize a Vector3 to store the player's velocity.
        velocity += transform.forward * v * speed;  //Add the "Vertical" input to the player's velocity.
        velocity += transform.right * h * speed;    //Add the "Horizontal" input to the player's velocity.
        pawn.SimpleMove(velocity);                  //Move the player using the combined velocity Vector3.
    }

    // [TODO:] possible means of aiming player?
    private void AimPlayer()
    {

    }
}
