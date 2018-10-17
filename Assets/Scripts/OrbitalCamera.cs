using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls how the camera circles around a fixed point.
/// </summary>
public class OrbitalCamera : MonoBehaviour {

    /// <summary>
    /// The minimum angle that the camera can exist in "Vertical" space.
    /// </summary>
    private const float Y_ANGLE_MIN = -80f;
    /// <summary>
    /// The maximum angle that the camera can exist in "Vertical" space.
    /// </summary>
    private const float Y_ANGLE_MAX = 80f;

    /// <summary>
    /// Stores the pitch of the camera.
    /// </summary>
    private float pitch = 0;
    /// <summary>
    /// Stores the yaw of the camera.
    /// </summary>
    private float yaw = 0;

    /// <summary>
    /// Controls whether or not to invert the "Horizontal" controls of the Camera.
    /// </summary>
    public bool invertLookX = false;
    /// <summary>
    /// Controls whether or not to invert the "Vertical" controls of the Camera.
    /// </summary>
    public bool invertLookY = false;

    /// <summary>
    ///  The "Horizontal" sensitivity of the Camera's controls.
    /// </summary>
    public float lookSensitivityX = 4.0f;
    /// <summary>
    /// The "Vertical" sensitivity of the Camera's controls.
    /// </summary>
    public float lookSensitivityY = 1.0f;
	
	/// <summary>
    /// Update is called upon once every frame to update the object.
    /// </summary>
	void Update () {
        lookAround();                                                                           //Call upon the lookAround() function.
    }

    private void lookAround()
    {
        float lookX = Input.GetAxis("Mouse X") * (invertLookX ? -1 : 1) * lookSensitivityX;     //Store the horizontal change of the camera.
        float lookY = Input.GetAxis("Mouse Y") * (invertLookY ? -1 : 1) * lookSensitivityY;     //Store the vertical change of the camera.

        pitch += lookY;                                                                         //Add the vertical change of the camera to its pitch.
        pitch = Mathf.Clamp(pitch, Y_ANGLE_MIN, Y_ANGLE_MAX);                                   //Clamp the pitch of the camera based on its min and max angles.

        yaw += lookX;                                                                           //Add the horizontal change of the camera to its yaw.

        transform.localEulerAngles = new Vector3(pitch, yaw, 0);                                //Apply the pitch and yaw to the cmaera's local euler angles.
    }
}
