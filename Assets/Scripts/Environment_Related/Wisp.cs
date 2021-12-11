using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour
{
    string PlayerName = "SideScrollPlayer";
    public bool isCollected = false; 
    public GameObject[] wisps;

    public int wispPoints = 0;
    // private AudioSource source;

    



    void Start()
    {
        // source = GameObject.FindGameObjectWithTag("wispAudio").GetComponent<AudioSource>(); ;
        //Setting all wisps to active
        foreach (GameObject go in wisps)
        {
            go.SetActive(true);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == PlayerName)
        {
            
            isCollected = true;

            //Destroy(gameObject);
            //setting triggered wisp to active == false
            
            // source.Play();
            gameObject.SetActive(false);
             
        }

    }


}
