using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Satellite : MonoBehaviour
{
    public float speed;
    public float mapWidth;
    public int lives;

    public Rigidbody2D rb;
    public TMP_Text livesText;
    public GameObject gameOverMenu;
    private SpriteRenderer spriteRenderer;
    private Vector2 startPosition;
    void Awake()
    {
        speed = 20f;
        mapWidth = 8f;
        lives = 3;
    }

    void Start()
    {
        startPosition = transform.position;
        gameOverMenu.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        Vector2 newPosition = rb.position + Vector2.right * x; // rb.position is the users current position
                                                               // Vector2.right is saying 1x and 0y movement
                                                               // x allows us to also go -1 or to the Left
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        rb.MovePosition(newPosition);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid")) {
            GetComponent<Collider2D>().enabled = false;
            lives--;
            UpdateLivesText();
            if (lives > 0)
            {
                ResetPlayerAndAsteroids();
            }
            else
            {
                ShowGameOver();
            }
        }
    }

    private void ResetPlayerAndAsteroids()
    {
        StartCoroutine(FlashPlayer());
        transform.position = startPosition;
        Object.FindFirstObjectByType<AsteroidSpawner>().ClearAsteroids(2);
        //yield return new WaitForSeconds(1f);
        //Object.FindFirstObjectByType<AsteroidSpawner>().SpawnAsteroids();
        GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator FlashPlayer()
    {
        for (int i = 0; i < 6; i++)  // Flash 3 times (on/off 6 times)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;  // Toggle sprite visibility
            yield return new WaitForSeconds(0.2f);  // Wait 0.2 seconds between flashes
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;  // Update UI text
    }

    private void ShowGameOver()
    {
        gameOverMenu.SetActive(true);  // Show Game Over menu
        Time.timeScale = 0f;  // Pause the game
    }






}