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


    public Collider2D player;
    public Collider2D spike;


    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        spike = GameObject.FindGameObjectWithTag("spike").GetComponent<Collider2D>();
    }




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

    private void Update()
    {
        IsTouchingSpike();
    }



    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            SetTouchedSpike(true);


            // this is updating health value and manager reacts to it
            health.TakeOneDamage();

           

            StartCoroutine(timer());

            
           
        }

       

    }
    

    public void IsTouchingSpike()
    {
        if (player.IsTouching(spike))
        {
            print("Player hit Spikes! And health is blah blah bbb " + health);
            SetTouchedSpike(true);
            
        }
        else
        {
            SetTouchedSpike(false);
            print("Player did not hit ht hit hit Spikes! " + health);
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


    IEnumerator timer()//this is a corroutine
    {
        int time = 5;

        while (GetTouchSpike() == true)
        {
            
            yield return new WaitForSeconds(time);

            if(GetTouchSpike() == true)
            {
                health.TakeOneDamage();
            }
        }

    }
}
