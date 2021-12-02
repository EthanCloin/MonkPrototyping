using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
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

    private void FixedUpdate()
    {
        if (gameObject.GetComponent<SpikeBehavior>().playerTouched == true)
        {
            health--;
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


}
