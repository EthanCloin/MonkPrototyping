using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkPlayer : MonoBehaviour
{
    public float moveSpeed = 0.05f;
    public Transform movePoint;
    [SerializeField] private LayerMask collidableLayer;
    public float collisionRadius = 0.1f;
    

    private void Start()
    {
        movePoint.parent = null;
    }

    private void Update()
    {
        // move player towards its movePoint
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed);

        // only move player if it has arrived to same tile as movePoint
        if (movePoint.position == transform.position)
        {
            // check for collisions on collidable layer using OverlapCircle
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0,0), collisionRadius, collidableLayer))
            {
                // apply L/R movement
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
                {
                    movePoint.position += (new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                }
            }

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), collisionRadius, collidableLayer))
            {
                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
                {
                    movePoint.position += (new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
                }
            }
                

        }
        


    }
    //[SerializeField] private Rigidbody2D rb;
    //private bool movingLeft, movingRight, isJumping;
    //public float movementSpeed = 10.0f;
    //public float jumpStrength = 10.0f;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // check for user inputs

    //    // RIGHT ARROW
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        movingRight = true;
    //    }

    //    // LEFT ARROW
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        movingLeft = true;
    //    }

    //    // UP ARROW
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        isJumping = true;
    //    }


    //}

    ///*
    // * For applying physics actions
    // */
    //private void FixedUpdate()
    //{
    //    Vector2 curVelocity = rb.velocity;


    //    // apply movement to rigidbody
    //    if (movingRight)
    //    {
    //        rb.velocity = new Vector2(movementSpeed, curVelocity.y);
    //        movingRight = false;
    //    }

    //    if (movingLeft)
    //    {
    //        rb.velocity.Set(-movementSpeed, curVelocity.y);
    //        movingLeft = false;
    //    }

    //    if (isJumping)
    //    {
    //        rb.velocity.Set(curVelocity.x, jumpStrength);
    //        isJumping = false;
    //    }
    //}
}
