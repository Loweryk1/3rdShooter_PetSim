using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls shooting mechanics for the player.
/// </summary>
public class ShootBullet : MonoBehaviour {

    public float bulletSpawnTimerMax = 2.0f;

    /// <summary>
    /// Stores the prefab of the bullet that is fired.
    /// </summary>
    public GameObject bulletPrefab;
    /// <summary>
    /// Stores the spawn location of the bullets.
    /// </summary>
    public Transform bulletSpawn;

    /// <summary>
    /// Stores the current time until the next bullet can be fired.
    /// </summary>
    public float coolDown = 0;

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))                           //If the 'Fire1' input is pressed...
        {
            Fire();                                                 //Call the Fire() function
        }
        if(coolDown > 0) coolDown-= Time.deltaTime;                            //If the coolDown timer greater than 0, it counts down deltaTime.
        print("Cooldown time for bullets: " + coolDown);
	}

    //Fire prepares and shoots bullets.
    void Fire()
    {
        if (coolDown <= 0)
        {
            //Adjust the player so it is facing the same direction as the Orbital Camera.
            GetComponent<OrientPlayer>().TurnAround();

            //Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            //Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

            //Detroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
            coolDown = bulletSpawnTimerMax;
        }
    }
}
