using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : MonoBehaviour
{
 public Transform player;
public Transform enemy;
public float jumpDistance = 2f;
public float jumpForce = 5f;
public float jumpDelay = 2f;

private float nextJumpTime = 0f;

void Update()
{
    if (Time.time > nextJumpTime)
    {
        if (player.position.y > enemy.position.y && Vector2.Distance(player.position, enemy.position) < jumpDistance)
        {
            Jump();
            nextJumpTime = Time.time + jumpDelay;
        }
    }
}

void Jump()
{
    enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
}

}
