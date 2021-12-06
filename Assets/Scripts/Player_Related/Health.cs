using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 3;
    public int numOfHearts = 3;

    public Image[] hearts; 
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool isDead = false;

    public static Health control;

    public Manager manager;


    void Update()
    {
        
        
        for (int i = 0; i < hearts.Length; i++)
        {
            
            //make sure health is not more than the number of hearts
            if(health > numOfHearts)
            {
                health = numOfHearts;
            }

            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            

            //
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void FixedUpdate()
    {
        
        if (SpikeBehavior.control.GetTouchSpike() == true)
        {
            //LoseOneHeart();
            //print("Player hit Spikes! And health is " + health);

            //SpikeBehavior.control.SetTouchedSpike(false);

            if(health == 0)
            {
                SetIsDead(true);
                Death(); 
            }

        }
    }


    public void LoseOneHeart ()
    {

        if (health != 0)
        {
            health--;
        }
    }

    public void Death ()
    {
        manager.FreezeTime();
        manager.ShowDeathScreen();
    }


    //prints to the screen that you die and quit the game
    private void OnGUI()
    {
        if (isDead)
        {

            GUI.Label
                (
                new Rect(20, 10, Screen.width, Screen.height),
                "You Died!"
                );
            Application.Quit();

        }//end if
    }//end method

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


    public bool GetIsDead()
    {
        return isDead;
    }


    public void SetIsDead(bool value)
    {
        isDead = value;
    }
}
