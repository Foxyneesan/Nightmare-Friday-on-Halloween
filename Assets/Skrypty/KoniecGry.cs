using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoniecGry : MonoBehaviour
{
	
void OnCollisionEnter2D(Collision2D collision)
{

	Debug.Log("Kolizja wykryta");
	
    if (collision.gameObject.tag == "Enemy")
    {
        SceneManager.LoadScene("SampleScene");
    }
}
}
