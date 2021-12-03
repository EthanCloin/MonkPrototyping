using UnityEngine;
using System.Collections;

public class BoatMovement : MonoBehaviour
{
    public float accel = 1.0f;
    public float maxSpeed = 2.0f;
    public float jumpSpeed = 1.0f;
    Rigidbody2D rigidBody2D;
    bool right;
    bool left;
    bool jump;


    void FixedUpdate()
    {
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                rigidBody2D.velocity = new Vector2(accel * -1, rigidBody2D.velocity.y);
            if (Input.GetKey(KeyCode.RightArrow))
                rigidBody2D.velocity = new Vector2(accel, rigidBody2D.velocity.y);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            left = true;
        }
        else
        {
            left = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
        }
        else
        {
            right = false;
        }
        if ((Input.GetKeyDown(KeyCode.Space)
|| Input.GetKeyDown(KeyCode.UpArrow))
&& rigidBody2D.velocity.y.Equals(0))
        {
            jump = true;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        var joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = c.rigidbody;
    }
}