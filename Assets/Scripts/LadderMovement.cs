using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public float climbSpeed = 3f;

    private bool isClimbing = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float verticalInput = Input.GetAxis("Vertical");

            if (verticalInput != 0)
            {
                isClimbing = true;
                collision.attachedRigidbody.gravityScale = 0f;
                collision.attachedRigidbody.velocity = new Vector2(collision.attachedRigidbody.velocity.x, verticalInput * climbSpeed);
            }
            else
            {
                isClimbing = false;
                collision.attachedRigidbody.gravityScale = 1f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimbing = false;
            collision.attachedRigidbody.gravityScale = 1f;
        }
    }
}