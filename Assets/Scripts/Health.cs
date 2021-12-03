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

        /*if (gameObject.GetComponent<SpikeBehavior>().playerTouched == true)
        {   
            health--;
        }*/
    }

    void FixedUpdate()
    {
        
        if (SpikeBehavior.control.getTouchSpike() == true)
        {
            LoseOneHeart();
            print("Player hit Spikes! And health is " + health);

            SpikeBehavior.control.setTouchedSpike(false);

            if(health == 0)
            {
                Death(); 
            }

        }
    }
    //NullReferenceException: Object reference not set to an instance of an objectHealth.FixedUpdate() (at Assets/Scripts/Health.cs:51)


    public void LoseOneHeart ()
    {

        if (health != 0)
        {
            health--;
        }
    }

    public void Death ()
    { 
           Application.Quit();
        
    }


    //prints to the screen that you die and quit the game
    private void OnGUI()
    {
        if (health == 0)
        {
            GUI.Label
                (
                new Rect(20, 10, Screen.width, Screen.height),
                "You Died!"
                );
            Application.Quit();

        }//end if
    }//end method




}
