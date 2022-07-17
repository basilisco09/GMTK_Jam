using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private float horizontal;
    private bool isFacingRight = true;
    private int jumpCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space") && jumpCounter < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCounter++;
        }
        if (Input.GetKeyDown("space") && jumpCounter > 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.8f);
            jumpCounter++;
        }
        if (IsGrounded())
        {
            jumpCounter = 0;
        }
        Flip();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if((horizontal < 0f && isFacingRight) || (horizontal > 0f && !isFacingRight))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
