using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to detect the current input devices supported by the code that are plugged in to the computer.
/// </summary>
public class DetectInput : MonoBehaviour {
    /// <summary>
    /// This stores the input number of an Xbox 360 Controller
    /// </summary>
    private const int XBOX_360_INPUT = 22;
    /// <summary>
    /// This stores if an Xbox 360 controller is currently plugged into the computer.
    /// </summary>
    private bool Xbox_360_Controller = false;
	
	/// <summary>
    /// Update checks every frame for new controller inputs.
    /// </summary>
	void Update () {
        string[] inputNames = Input.GetJoystickNames();
        for(int x = 0; x < inputNames.Length; x++)
        {
            //print(inputNames[x].Length);
            if(inputNames[x].Length == XBOX_360_INPUT)
            {
                print("XBOX 360 CONTROLLER IS CONNECTED");
                Xbox_360_Controller = true;
            }
        }
	}
    /// <summary>
    /// This function is used to call for the boolean values of a specific controller type.
    /// </summary>
    /// <param name="type">The type of controller we're checking to see if its connected to the computer.</param>
    /// <returns></returns>
    public bool HasInput(string type)
    {
        switch (type)
        {
            case "Xbox 360":
                return Xbox_360_Controller;
            default:
                return false;
        }
    }
}
