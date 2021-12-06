using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public Manager manager;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        manager.CompleteLevel();
        print("Leve won inside trigger");
    }
}
