using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LewitacjaOrb : MonoBehaviour
{
    public float speed = 1f;
    public float height = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
