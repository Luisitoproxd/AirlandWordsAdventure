using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float runSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float moveX = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = runSpeed;
            sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -runSpeed;
            sr.flipX = true;
        }

        rb.velocity = new Vector2(moveX, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
