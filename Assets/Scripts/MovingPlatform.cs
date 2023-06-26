using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public Transform leftBound;
    public Transform rightBound;

    private bool movingRight = true;

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingRight)
            transform.position = Vector2.MoveTowards(transform.position, rightBound.position, step);
        else
            transform.position = Vector2.MoveTowards(transform.position, leftBound.position, step);

        if (transform.position == rightBound.position)
            movingRight = false;
        else if (transform.position == leftBound.position)
            movingRight = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
