using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class makes the rays created by the Camera 'tpsCam' visible in editor.
/// </summary>
public class RayViewer : MonoBehaviour {

    /// <summary>
    /// The max range the weapon on the player is able to fire.
    /// </summary>
    public float weaponRange = 50f;
    /// <summary>
    /// The Camera we want to draw a ray from.
    /// </summary>
    public Camera tpsCam;

	/// <summary>
    /// Updates the raycast draw in every frame.
    /// </summary>
	void Update () {
        Vector3 lineOrigin = tpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(lineOrigin, tpsCam.transform.forward * weaponRange, Color.green);
	}
}
