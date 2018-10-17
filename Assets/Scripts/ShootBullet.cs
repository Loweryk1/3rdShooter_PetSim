using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls shooting mechanics for the player.
/// </summary>
public class ShootBullet : MonoBehaviour {

    /// <summary>
    /// Stores the amount of damage this gun does to objects.
    /// </summary>
    public int gunDamage = 1;
    /// <summary>
    /// Stores the current time until the next bullet can be fired.
    /// </summary>
    public float fireRate = .25f;
    /// <summary>
    /// Controls the max distance a raycast bullet is able to travel.
    /// </summary>
    public float weaponRange = 50.0f;
    /// <summary>
    /// Stores how hard the gun hits for blowback purposes.
    /// </summary>
    public float hitForce = 100f;
    /// <summary>
    /// Stores the location of the end of the gun.
    /// </summary>
    public Transform gunEnd;

    /// <summary>
    /// References the Camera we are drawing the aim raycast from.
    /// </summary>
    public Camera tpsCam;
    /// <summary>
    /// Stores how long the shot lasts in the game.
    /// </summary>
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    /// <summary>
    /// Stores the audio for the gunshot heard when the weapon is fired.
    /// </summary>
    private AudioSource gunAudio;
    /// <summary>
    /// This draws a straight line between two or more points in a straight line between them in the game view.
    /// </summary>
    private LineRenderer laserLine;
    /// <summary>
    /// Stores the time at which the player will be allowed to fire again after firing.
    /// </summary>
    private float nextFire;

	/// <summary>
    /// Use this function when instantiating a new object with this script attached.
    /// </summary>
	void Start () {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
    }

	/// <summary>
    /// Update is called once every frame to update the object.
    /// </summary>
	void Update () {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = tpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if(Physics.Raycast(rayOrigin, tpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                laserLine.SetPosition(1, tpsCam.transform.forward * weaponRange);
            }

            ShootableTarget health = hit.collider.GetComponent<ShootableTarget>();
            if(health != null)
            {
                health.Damage(gunDamage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
        }
	}

    /// <summary>
    /// Is called upon alongside update to control any effects created by firing the gun.
    /// </summary>
    /// <returns>The amount of time this function remains active.</returns>
    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}
