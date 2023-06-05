using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
   /* public float jumpSpeed = 8f;*/
    private float jumpingPower = 16f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

/*    private Animator playerAnimation;*/

    private Vector3 respawnPoint;
    /*    public GameObject fallDetector;

        public Text scoreText;*/
    public Slider progressBar; // Slider lub Image reprezentuj�cy pasek post�pu
    private int score = 0;
    private int maxScore = 10; // Maksymalna warto�� punkt�w do zebrania


    /*    public HealthBar healthBar;
*/
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
/*        playerAnimation = GetComponent<Animator>();*/
        respawnPoint = transform.position;
/*        scoreText.text = "Score: " + Scoring.totalScore;*/
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.7f, 0.7f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-0.7f, 0.7f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpingPower);
        }

        /*        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
                playerAnimation.SetBool("OnGround", isTouchingGround);
        */
        /*        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*        if (collision.tag == "FallDetector")
                {
                    transform.position = respawnPoint;
                }*/
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        else if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Can also use SceneManager.LoadScene(1); to load a specific scene
            respawnPoint = transform.position;
        }
        else if (collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }
        /*        else if (collision.tag == "Crystal")
                {
                    Scoring.totalScore += 1;
                    scoreText.text = "Score: " + Scoring.totalScore;
                    collision.gameObject.SetActive(false);
                }*/
        if (collision.CompareTag("Coin"))
        {
            CollectCoin(collision.gameObject);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        score++; // Naliczanie punktacji
        progressBar.value = (float)score / maxScore; // Aktualizacja warto�ci paska post�pu

        Destroy(coin); // Usuni�cie zebranej monety
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            /*           healthBar.Damage(0.002f);*/
        }
    }

}