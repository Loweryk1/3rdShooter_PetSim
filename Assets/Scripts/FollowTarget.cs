using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the object this script is applied to to follow the transform component of another object specified.
/// </summary>
public class FollowTarget : MonoBehaviour {

    public Transform target;                    //The target we want to follow.
    public float easeMultiplier = 10;           //The amount of easing we want when adjusting to follow the target.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * easeMultiplier);        //Change this object's position to the position of the target.
        }
	}
}
