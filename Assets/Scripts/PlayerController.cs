using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float jumpingPower = 16f;
    private float direction = 0f;
    private Rigidbody2D player;
    private bool isTouchingGround;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private bool isOnMovingPlatform = false;
    private Transform currentPlatform = null;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.7f, 0.7f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-0.7f, 0.7f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpingPower);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            isOnMovingPlatform = true;
            currentPlatform = collision.transform.parent;
            transform.SetParent(currentPlatform);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            isOnMovingPlatform = false;
            currentPlatform = null;
            transform.SetParent(null);
        }
    }
}