using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float jumpingPower = 12f;
    public float jumpTime = 10f;

   public float delayTime = 11f;
  
void Start()
{
	gameObject.SetActive(true);
}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
		
            StartCoroutine(JumpPowerUp(other));
		Invoke("ActivateObject", delayTime);
		
        }
    }


    IEnumerator JumpPowerUp(Collider2D player)
    {
	
        Player controller = player.GetComponent<Player>();
        controller.jumpingPower = 14;
	
        yield return new WaitForSeconds(jumpTime);
        controller.jumpingPower = 7;
	gameObject.SetActive(false);

	
	
    
    }
	private void ActivateObject()
    {
        gameObject.SetActive(true);
    }

	
}
