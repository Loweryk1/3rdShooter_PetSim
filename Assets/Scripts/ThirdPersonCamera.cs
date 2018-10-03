using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    /// <summary>
    /// The minimum angle that the camera can exist in "Vertical" space.
    /// </summary>
    private const float Y_ANGLE_MIN = -50.0f;
    /// <summary>
    /// The maximum angle that the camera can exist in "Vertical" space.
    /// </summary>
    private const float Y_ANGLE_MAX = 50.0f;

    /// <summary>
    /// Stores the transform data of the object the camera is currently looking at.
    /// </summary>
    public Transform lookAt;
    /// <summary>
    /// Stores the position the camera will move to during its next update.
    /// </summary>
    [HideInInspector] public Transform camTransform;

    /// <summary>
    /// The camera from the scene that is acting as a third-person camera.
    /// </summary>
    private Camera cam;

    /// <summary>
    /// The distance between the camera and the target.
    /// </summary>
    private float distance = 10.0f;
    /// <summary>
    /// The current local "Horizontal" position of the Camera.
    /// </summary>
    private float currentX = 0.0f;
    /// <summary>
    /// The current local "Vertical" position of the Camera.
    /// </summary>
    private float currentY = 0.0f;

    /// <summary>
    /// Controls whether or not to invert the "Horizontal" controls of the Camera.
    /// </summary>
    private bool invertLookX = false;
    /// <summary>
    /// Controls whether or not to invert the "Vertical" controls of the Camera.
    /// </summary>
    private bool invertLookY = false;

    /// <summary>
    ///  The "Horizontal" sensitivity of the Camera's controls.
    /// </summary>
    private float lookSensitivityX = 4.0f;
    /// <summary>
    /// The "Vertical" sensitivity of the Camera's controls.
    /// </summary>
    private float lookSensitivityY = 1.0f;

    //Use this for initialization
    private void Start()
    {
        camTransform = transform;                                                               //Gets the current Transform of the object and stores it under "camTransform".
        cam = Camera.main;                                                                      //Stores the Main Camera of the scene under "cam".
    }

    //Update is called once per frame
    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * (invertLookX ? -1 : 1) * lookSensitivityX;       //Stores currentX by grabbing the "Mouse X" data, and adds in the invert preference and horizontal sensitivity of the camera.
        currentY += Input.GetAxis("Mouse Y") * (invertLookY ? -1 : 1) * lookSensitivityY;       //Stores currentY by grabbing the "Mouse Y" data, and adds in the invert preference and vertical sensitivity of the camera.

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);                             //Clamps currentY by using the angle min Y and angle max Y constants.
    }

    //LateUpdate is called once per frame after every object has updated
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);                                             //Creates a new Vector3 to store the local space the camera is moving to.
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);                          //Creates a new Quaternion to store the new rotational position around the target.
        camTransform.position = lookAt.position + rotation * dir;                               //Set where the Camera is by grabbing where its target is, then adding its new rotation and direction variables.
        camTransform.LookAt(lookAt.position);                                                   //Set the Camera to look at the target.

    }
}
