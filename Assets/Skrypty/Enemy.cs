using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    public float runDistance = 10.0f;
    public float walkDistance = 20.0f;
    public Transform player;

    private bool isRunning = false;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= runDistance)
        {
            isRunning = true;
        }
        else if (distance >= walkDistance)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
