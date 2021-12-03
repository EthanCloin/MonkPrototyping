using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;
    public bool isDead = false;
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -6) //if player falls below raft, mark as dead.
        {
            isDead = true;
        }
    }
    private void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");//get reference to player.
    }
}
