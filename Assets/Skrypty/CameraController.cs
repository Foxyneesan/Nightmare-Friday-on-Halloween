using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

   
    public void Update()
    {
        transform.position = player.position;
    }
}
