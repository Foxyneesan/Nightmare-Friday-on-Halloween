using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

	[field:SerializeField]
    private float jumpingPower = 16f;
    private float direction = 0f;
    private Rigidbody2D player;
    private bool isTouchingGround;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    public string nextLevelScene;
    public Slider progressBar;
    private int score = 0;
    public int maxScore = 10;
    private int coinsCollected = 0;

    private Vector3 respawnPoint;

    public Transform respaPoint;

    private bool isOnMovingPlatform = false;
    private Transform currentPlatform = null;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.65f, 0.65f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-0.65f, 0.65f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpingPower);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            transform.position = respawnPoint;
        }

        else if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }

        else if (collision.CompareTag("Coin"))
        {
            CollectCoin(collision.gameObject);
        }
        else if (collision.CompareTag("Platform"))
        {
            isOnMovingPlatform = true;
            currentPlatform = collision.transform.parent;
            transform.SetParent(currentPlatform);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            isOnMovingPlatform = false;
            currentPlatform = null;
            transform.SetParent(null);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        score++;
        progressBar.value = (float)score / maxScore;

        coinsCollected++;

        Destroy(coin);

        if (coinsCollected >= 10)
        {
            LoadNextLevel();
        }
    }
    private void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextLevelScene))
        {
            SceneManager.LoadScene(nextLevelScene);
        }
    }
}