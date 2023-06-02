using UnityEngine;


public class ChaseingEnemy : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public float chaseDistance = 10.0f;
    public float speed = 5.0f;
    public float jumpForce = 5.0f;

    private bool isJumping = false;
    private Rigidbody2D enemyRigidbody;
	public float jumpDelay = 1.0f;
	 private float jumpTimer = 0.0f;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector2.Distance(player.position, enemy.position);

        if (distance < chaseDistance)
        {
            Vector2 direction = (player.position - enemy.position).normalized;
            enemy.Translate(direction * speed * Time.deltaTime);

            if (!isJumping)
            {

               
             jumpTimer += Time.deltaTime;

            if (jumpTimer >= jumpDelay)
            {
                 enemyRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
                jumpTimer = 0.0f;
            }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}