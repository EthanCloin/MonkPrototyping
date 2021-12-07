using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class manages health information and passes it along
/// to the Manager to update display
///
/// Singleton
/// 
/// </summary>
public class Health
{
    private static Health playerHealth = null;
    public int currentHealth;
    public int maximumHealth = 3;
    // public Manager manager;
    // public bool isDead;

    // constructor
    private Health()
    {
        currentHealth = maximumHealth;
    }

    // instance method ensures only 1 health object exists
    public static Health GetInstance()
    {
        if (playerHealth == null)
            playerHealth = new Health();

        return playerHealth;
    }

    /// <summary>
    /// Call this function to decrement and return the health value
    /// </summary>
    /// <returns>int currentHealth after taking damage</returns>
    public int TakeOneDamage()
    {
        return currentHealth--;
    }

    /// <summary>
    /// Call this function to return current health
    /// </summary>
    /// <returns>int currentHealth</returns>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Call this function to reset health value to max
    /// </summary>
    public void RestoreFullHealth()
    {
        currentHealth = maximumHealth;
    }


    // Let Manager handle UI Updates
    //public void Death()
    //{
    //    print("Death State reached " + currentHealth);
    //    //manager.ShowDeathScreen();
        
    //}




    

}
