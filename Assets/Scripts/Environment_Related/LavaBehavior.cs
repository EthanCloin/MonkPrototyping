using UnityEngine;

public class LavaBehavior : MonoBehaviour
{

    public bool touchedSpike = false;
    // public Manager mgr;
    // public static SpikeBehavior control;
    public string playerTag = "Player";
    public Health health;

    void Awake()
    {
        health = Health.GetInstance();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // check that collision is with Player
        if (collision.gameObject.CompareTag(playerTag))
        {
            print("Player hit lava!");
            health.TakeOneDamage();
            health.TakeOneDamage();
            health.TakeOneDamage();
        }
    }
}
