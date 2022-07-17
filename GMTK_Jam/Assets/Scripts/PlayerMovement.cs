using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private Animator animator;
    private GameObject pauseMenu;
    private Pause pause;
    private float horizontal;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool gamePaused;

    private int jumpCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        if (pauseMenu != null)
        {
            pause = pauseMenu.GetComponent<Pause>();
            gamePaused = pause.gameIsPaused;
        }
        Debug.Log(gamePaused);
        if (!gamePaused)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown("space") && jumpCounter == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCounter++;
            }
            if (Input.GetKeyDown("space") && jumpCounter == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.8f);
                jumpCounter++;
            }
            if (isGrounded)
            {
                jumpCounter = 0;
            }
            Flip();
            CheckSurround();
        }

        if(rb.velocity.y != 0)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsRuning", false);
            animator.SetBool("IsIdle", true);
        }
    }

    private void FixedUpdate()
    {
            if (!isGrounded && isTouchingWall)
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
    }

    private void Flip()
    {
            if ((horizontal < 0f && isFacingRight) || (horizontal > 0f && !isFacingRight))
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
            }
    }

    private void CheckSurround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (isFacingRight)
        {
            Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));        
        }
        else
        {
            Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x - wallCheckDistance, wallCheck.position.y));
        }
    }
}
