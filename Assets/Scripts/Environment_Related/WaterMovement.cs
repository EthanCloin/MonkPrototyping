using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
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
        for (int i = 0; i < 10; i++)
        {
            //test();
            //spriteRenderer.flipY = true;
            //test();
            //spriteRenderer.flipY = false;
        }
    }

    // Update is called once per frame
    void Update()
    {



    }
}