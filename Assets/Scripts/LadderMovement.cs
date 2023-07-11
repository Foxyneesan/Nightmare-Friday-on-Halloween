using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public float climbSpeed = 3f;

    private bool isClimbing = false;
    private GameObject player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            float verticalInput = Input.GetAxis("Vertical");

            if (verticalInput != 0)
            {
                isClimbing = true;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, verticalInput * climbSpeed);
            }
            else
            {
                isClimbing = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimbing = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 0f);
            player = null;
        }
    }

    private void Update()
    {
        if (isClimbing && player != null)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput * climbSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
