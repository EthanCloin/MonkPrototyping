using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{
    public int wispsCollected;
    // Start is called before the first frame update
    void Start()
    {
        wispsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        wispsCollected++;
    }
}
