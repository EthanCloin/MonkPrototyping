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
        OnGui();
    }
    private void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");//get reference to player.
    }
    //prints to the screen that you die and quit the game
    private void OnGui()
    {
        if (isDead == true)
        {
            //setPlayerStatus(true);

            GUI.Label
                (
                new Rect(20, 10, Screen.width, Screen.height),
                "You Died!"
                );
            Application.Quit();

        }//end if
    }//end method
}
