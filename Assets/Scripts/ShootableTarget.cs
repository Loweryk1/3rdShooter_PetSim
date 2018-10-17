using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is applied to any target we want the gun on the player to be able to shoot.
/// </summary>
public class ShootableTarget : MonoBehaviour {
    /// <summary>
    /// This stores the current health of the object.
    /// </summary>
    public int currentHealth = 3;
	
    /// <summary>
    /// We call this function whenever the object takes damage.
    /// </summary>
    /// <param name="damageAmount"> The amount of damage we want to apply to the object.</param>
    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
