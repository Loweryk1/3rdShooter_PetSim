using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the direction the player is facing based on the camera's position.
/// </summary>
public class OrientPlayer : MonoBehaviour {

    /// <summary>
    /// Stores the OrbitalCamera that is following the player.
    /// </summary>
    public OrbitalCamera orbitCam;

    void Start() { }

    /// <summary>
    /// Is called to rotate the player to the direction an OrbitalCamera is facing using the player's euler angles.
    /// </summary>
    public void TurnAround()
    {
        float camYaw = orbitCam.transform.localEulerAngles.y;   //Stores the Yaw of the OrbitalCamera.
        transform.eulerAngles = new Vector3(0, camYaw, 0);      //Adjusts the rotation of this object using Euler Angles.
    }
}
