using System;
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
<<<<<<< HEAD

=======
>>>>>>> 2128b60eaa3daaf62878e0af684195c2f7513f55

    private bool isOnMovingPlatform = false;
    private Transform currentPlatform = null;

    public Image[] hearts;
    public Sprite blackHeartSprite;
    public Sprite redHeartSprite;
    private int currentLives = 3;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        respawnPoint = respaPoint.position;
        UpdateUI();
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
            LoseLife();
        }

        else if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = respaPoint.position;
        }
        else if (collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = respaPoint.position;
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
    private void LoseLife()
    {
        currentLives--;
        UpdateUI();

        if (currentLives <= 0)
        {
            // Kod, który wykonuje siê po utraceniu wszystkich ¿yæ
            Debug.Log("Game Over!");
        }
        else
        {
            // Zmiana obrazka serduszka na czarne serduszko
            hearts[currentLives].sprite = blackHeartSprite;
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].sprite = redHeartSprite;
            }
            else
            {
                hearts[i].sprite = blackHeartSprite;
            }
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