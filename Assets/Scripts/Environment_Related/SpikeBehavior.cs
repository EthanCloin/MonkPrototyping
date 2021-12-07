using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{

    public bool touchedSpike = false;
    // public Manager mgr;
    // public static SpikeBehavior control;
    public string playerTag = "Player";
    public Health health;
    public SideScrollPlayer player;
    // public bool isInvincible = false;


    // public Collider2D player;
    // public Collider2D spike;



    /// <summary>
    /// get the player and spike game components
    /// </summary>
    private void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        // spike = GameObject.FindGameObjectWithTag("spike").GetComponent<Collider2D>();
    }




    void Awake()
    {
        //if (control != null)
        //{
        //    Destroy(this);
        //}
        //else
        //{
        //    control = this;
        //}

        health = Health.GetInstance();
     
    }
    /// <summary>
    /// checks frame by frame to see if player is touching spike
    /// </summary>
    
    //void Update()
    //{
    //    IsTouchingSpike();
      
    //}



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

        //if (health.GetCurrentHealth() > 0)
        //{
        //    if (collision.gameObject.tag == playerTag)
        //    {
        //        SetTouchedSpike(true);



            //        // this is updating health value and manager reacts to it
            //        if (isInvincible == false)
            //        {
            //            health.TakeOneDamage();
            //            //StartCoroutine(timer());
            //            //StartCoroutine(invincible());
            //        }

            //    }

            //}
            //else
            //{
            //    health.Death();
            //}

    }

    /// <summary>
    /// check if player is currently touching spike
    /// </summary>
    //public void IsTouchingSpike()
    //{
    //    if (player.IsTouching(spike))
    //    {
    //        print("Player touching Spikes! " + health);
    //        SetTouchedSpike(true);

    //    }
    //    else
    //    {
    //        SetTouchedSpike(false);
    //        print("Player did not touching Spikes! " + health);
    //    }
    //}



    //public bool GetTouchSpike()
    //{
    //    return touchedSpike;
    //}


    //public void SetTouchedSpike(bool value)
    //{
    //    touchedSpike = value;
    //}

    /// <summary>
    /// checks if player is continuously touching spike and takes one health if it is so
    /// </summary>
    //IEnumerator timer()//this is a corroutine
    //{
    //    int time = 5;

    //    while (GetTouchSpike() == true)
    //    {
    //        if (GetTouchSpike() == false)
    //        {
    //            time = 5;
    //        }

    //        yield return new WaitForSeconds(time);

    //        if(GetTouchSpike() == false)
    //        {
    //            time = 5;
    //        }
    //        if (health.GetCurrentHealth() > 0)
    //        {
    //            if (GetTouchSpike() == true)
    //            {
    //                health.TakeOneDamage();
    //            }
    //        }

    //        else
    //        {
    //            health.Death();
    //        }
    //    }

    //}

    /// <summary>
    /// create a 4.5 seconds invvincibility window after damage is taken
    /// </summary>
    //IEnumerator TemporaryInvincibility()//this is a corroutine
    //{
    //    float time = 4.5f;

    //    isInvincible = true;
    //    print("Invincible!!!");

    //    // bool flag = true;

    //    while (true)
    //    {
    //        yield return new WaitForSeconds(time);
    //        isInvincible = false;
    //        print("End Invincibility");
    //    }


    //}
}
