using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float walkSpeed = 4f;
    public float jumpForce = 5f;

    public Transform groundChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;


    public bool moveRight = false, moveLeft = false, jump = false;
    public bool isGrounded;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Health healthbar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.control.GetIsDead() == false)
        {
            MoveListener();
            CheckIfGrounded();
            JumpListener();
        }
        
    }

    private void FixedUpdate()
    {
        if (Health.control.GetIsDead() == false)
        {
            MoveActor();
            JumpActor();
            BetterJump();
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    /// <summary>
    /// Sets moveRight/moveLeft flags indicating user movement
    /// </summary>
    void MoveListener()
    {
        // RIGHT
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight = true;
            sr.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveRight = false;
        }

        //LEFT
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft = true;
            sr.flipX = false;   
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveLeft = false;
        }
    }

    /// <summary>
    /// Controls horizonatal movement based on moveRight/moveLeft flags
    /// </summary>
    void MoveActor()
    {
        if (moveRight)
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
        else if (moveLeft)
        {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    /// <summary>
    /// Sets jump flag based on user input
    /// </summary>
    void JumpListener()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }
    }

    /// <summary>
    /// Controls vertical movement based on jump flag and groundChecker
    /// </summary>
    void JumpActor()
    {
        if (jump && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
        }
        else if (jump && !isGrounded)
        {
            jump = false;
        }
    }

    /// <summary>
    /// Changes jump trajectory to rise slowly and fall quickly
    /// </summary>
    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && (!Input.GetKey(KeyCode.Space) || !Input.GetKey(KeyCode.UpArrow)))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void TakeDamage()
    {
        // lose a heart
        healthbar.LoseOneHeart();
        rb.AddForce(new Vector2(-1, jumpForce), ForceMode2D.Impulse);
    }

}
