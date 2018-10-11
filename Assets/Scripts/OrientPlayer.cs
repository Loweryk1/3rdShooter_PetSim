using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientPlayer : MonoBehaviour {

    /// <summary>
    /// Stores the OrbitalCamera that is following the player.
    /// </summary>
    public OrbitalCamera orbitCam;

    void Start() { }

    public void TurnAround()
    {
        float camYaw = orbitCam.transform.localEulerAngles.y;   //Stores the Yaw of the OrbitalCamera.
        transform.eulerAngles = new Vector3(0, camYaw, 0);      //Adjusts the rotation of this object using Euler Angles.
    }
}
