using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbParticle : MonoBehaviour
{
   
[SerializeField] ParticleSystem orbParticle;
   
    void Update()
    {
	void OnTriggerEnter2D(Collider2D collision)
{
        if (collision.CompareTag("Coin"))
	{
		orbParticle.Play();
		
	}
    }
}
}
