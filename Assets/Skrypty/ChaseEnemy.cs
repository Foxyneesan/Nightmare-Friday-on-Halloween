using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
  public Transform player;
public Transform enemy;
public float chaseDistance = 10.0f;
public float moveSpeed = 5.0f;
private Rigidbody2D enemyRigidbody;

 private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

void Update () {
    float distance = Vector3.Distance(player.position, enemy.position);
    if (distance < chaseDistance) 
{
           Vector2 direction = (player.position - enemy.position).normalized;
            enemy.Translate(direction * moveSpeed * Time.deltaTime);
    }
}

 private void FixedUpdate()
    {
       
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0f);
      
        Vector2 newPosition = enemyRigidbody.position + movement * moveSpeed * Time.fixedDeltaTime;
      
        newPosition.y = enemyRigidbody.position.y;
        
        enemyRigidbody.MovePosition(newPosition);
    }
}
