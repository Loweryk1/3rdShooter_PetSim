using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the object this script is applied to to follow the transform component of another object specified.
/// </summary>
public class FollowTarget : MonoBehaviour {
    /// <summary>
    /// The target of the camera we wish to follow.
    /// </summary>
    public Transform target;
    /// <summary>
    /// The amount of easing we want when adjusting the camera to follow the target.
    /// </summary>
    public float easeMultiplier = 10;
	
	/// <summary>
    /// Update is called upon once every frame to update the object.
    /// </summary>
	void Update () {
		if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * easeMultiplier);        //Change this object's position to the position of the target.
        }
	}
}
