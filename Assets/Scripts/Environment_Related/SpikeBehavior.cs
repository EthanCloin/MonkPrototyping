using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{

    public bool touchedSpike = false;
    public Manager mgr;
    public static SpikeBehavior control;



    // Update is called once per frame
    void Update()
    {
        
    }

    // Start is called before the first frame update
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
    }//end method

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //print("Player hit Spikes!");
            


            setTouchedSpike(true); //reset to false after

            
        }
        
    }

    public bool getTouchSpike()
    {
        return touchedSpike;
    }


    public void setTouchedSpike(bool value)
    {
        touchedSpike = value;
    }
}
