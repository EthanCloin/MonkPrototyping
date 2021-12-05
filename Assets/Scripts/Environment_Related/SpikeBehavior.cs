using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{

    public bool touchedSpike = false;
    public Manager mgr;
    public static SpikeBehavior control;
    public string playerTag = "Player";
    public RefactoredHealth health;


    void Awake()
    {
        if (control != null)
        {
            Destroy(this);
        }
        else
        {
            control = this;
        }

        health = RefactoredHealth.getInstance();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            SetTouchedSpike(true); //reset to false in Manager

            // this is updating health value and manager reacts to it
            health.TakeOneDamage();
        }
        
    }

    public bool GetTouchSpike()
    {
        return touchedSpike;
    }


    public void SetTouchedSpike(bool value)
    {
        touchedSpike = value;
    }
}
