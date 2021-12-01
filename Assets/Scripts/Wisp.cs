using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour
{
    string PlayerName = "SideScrollPlayer";
    public bool isCollected = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == PlayerName)
        {
            gameObject.GetComponent<CollectWisp>().wispPoints++;
            isCollected = true;
            Destroy(gameObject);
        }

    }
}
