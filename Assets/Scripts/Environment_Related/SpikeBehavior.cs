using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{

    public bool touchedSpike = false;    
    public string playerTag = "Player";
    public Health health;
    public SideScrollPlayer player;
    

    void Awake()
    {       
        health = Health.GetInstance();     
    }    

    /// <summary>
    /// check for collision and removes health if not invincible
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check that collision is with Player
        if (collision.gameObject.CompareTag(playerTag) && !player.isInvincible)
        {
            player.HitSpike();
        }        
    }    
}
