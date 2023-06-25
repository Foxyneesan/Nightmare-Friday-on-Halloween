using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public Transform leftBound;
    public Transform rightBound;

    private Transform platformTransform;
    private bool movingRight = true;

    private void Start()
    {
        platformTransform = transform;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingRight)
            platformTransform.position = Vector3.MoveTowards(platformTransform.position, rightBound.position, step);
        else
            platformTransform.position = Vector3.MoveTowards(platformTransform.position, leftBound.position, step);

        if (platformTransform.position == rightBound.position)
            movingRight = false;
        else if (platformTransform.position == leftBound.position)
            movingRight = true;
    }
}