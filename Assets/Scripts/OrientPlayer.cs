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
    public Transform orbitCam;

    /// <summary>
    /// Update is called upon once every frame to update the object.
    /// </summary>
    public void Update()
    {
        float camYaw = orbitCam.eulerAngles.y;   //Stores the Yaw of the OrbitalCamera.
        transform.eulerAngles = new Vector3(0, camYaw, 0);      //Adjusts the rotation of this object using Euler Angles.
    }
}
