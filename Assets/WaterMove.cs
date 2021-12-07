using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        
        yield return 0;
    }

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        test();
        spriteRenderer.flipX = false;
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
