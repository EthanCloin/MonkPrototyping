using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{

    public bool playerTouched = false;
    public Manager mgr;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Player hit Spikes!");
            //gameObject.GetComponent<Health>().health--;
            playerTouched = true; //reset to false after
        }
        
    }
}
