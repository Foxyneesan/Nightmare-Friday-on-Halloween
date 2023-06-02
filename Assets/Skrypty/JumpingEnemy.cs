using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float jumpDelay = 1.0f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);

        if (isGrounded && !isJumping)
        {
            jumpTimer += Time.deltaTime;

            if (jumpTimer >= jumpDelay)
            {
                rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
                jumpTimer = 0.0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            isJumping = true;
        }
    }
}