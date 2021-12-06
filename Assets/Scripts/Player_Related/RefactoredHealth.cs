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
public class RefactoredHealth : MonoBehaviour
{
    private static RefactoredHealth playerHealth = null;
    private int currentHealth;
    public int maximumHealth = 3;
    public Manager manager;

    



    // constructor
    private RefactoredHealth()
    {
        currentHealth = maximumHealth;
    }

    // instance method ensures only 1 health object exists
    public static RefactoredHealth getInstance()
    {
        if (playerHealth == null)
            playerHealth = new RefactoredHealth();

        return playerHealth;
    }

    /// <summary>
    /// Call this function to decrement and return the health value
    /// </summary>
    /// <returns>int currentHealth after taking damage</returns>
    public int TakeOneDamage()
    {
        print("Player hit Spikes! And health is " + currentHealth);
        return currentHealth--;
    }

    /// <summary>
    /// Call this function to check current health
    /// </summary>
    /// <returns>int currentHealth</returns>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void RestoreFullHealth()
    {
        currentHealth = maximumHealth;
    }



    

}
