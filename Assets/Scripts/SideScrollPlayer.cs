using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private bool movingLeft, movingRight, isJumping;
    public float movementSpeed = 10.0f;
    public float jumpStrength = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // check for user inputs

        // RIGHT ARROW
        if (Input.GetKey(KeyCode.RightArrow))
        {
            print("right");
            movingRight = true;
        }

        // LEFT ARROW
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("left");
            movingLeft = true;
        }

        // UP ARROW
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            print("jump");
            isJumping = true;
        }


    }

    /*
     * For applying physics actions
     */
    private void FixedUpdate()
    {
        Vector2 curVelocity = rb.velocity;


        // apply movement to rigidbody
        if (movingRight)
        {
            rb.velocity = new Vector2(movementSpeed, curVelocity.y);
            movingRight = false;
        }

        if (movingLeft)
        {
            rb.velocity = new Vector2(-movementSpeed, curVelocity.y);
            movingLeft = false;
        }

        if (isJumping)
        {
            rb.velocity = new Vector2(curVelocity.x, jumpStrength);
            isJumping = false;
        }
    }
}
