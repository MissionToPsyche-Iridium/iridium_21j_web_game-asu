using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Satellite : MonoBehaviour
{
    public float speed;
    public float mapWidth;
    public int lives;
    public Rigidbody2D rb;
    public TMP_Text livesText;
    private Vector2 startPosition;
    public GameObject gameOverMenu;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        speed = 20f;
        mapWidth = 13f;
        lives = 3;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
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
    void OnCollisionEnter2D()
    {
        GetComponent<Collider2D>().enabled = false;
        lives--;
        //UpdateLivesText();
        if (lives > 0)
        {
            ResetPlayerAndAsteroids();
        }
        else
        {
            //ShowGameOver();
        }
    }

    private void ResetPlayerAndAsteroids()
    {
        // Flash player before resetting
        StartCoroutine(FlashPlayer());


        // Reset player immediately
        transform.position = startPosition;

        // Clear and respawn asteroids after delay
        Object.FindFirstObjectByType<AsteroidSpawner>().ClearAsteroids(2);
        // Wait for the player to flash before resetting asteroids
        //yield return new WaitForSeconds(1f);  // Add delay before respawning asteroids
        //Object.FindFirstObjectByType<AsteroidSpawner>().SpawnAsteroids();

        // Re-enable player's collider after resetting
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

    //public float speed;
    //public float mapWidth;
    //public bool collisionFlag = false;
    //private Rigidbody2D rb;
    //private Vector2 startPosition;
    //private SpriteRenderer spriteRenderer;

    //public int lives = 3;
    //public TMP_Text livesText;
    //public GameObject gameOverMenu;  
    //private RectTransform canvasRectTransform;


    //private void Awake()
    //{
    //    speed = 15f;
    //    lives = 3;
    //}

    //void Start()
    //{
    //    canvasRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
    //    UpdateMapWidth();

    //    gameOverMenu.SetActive(false);
    //    startPosition = transform.position;
    //    rb = GetComponent<Rigidbody2D>();
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //    UpdateLivesText();
    //}

    //private void Update()
    //{
    //    UpdateMapWidth();
    //}

    //void UpdateMapWidth()
    //{
    //    if (canvasRectTransform != null)
    //    {
    //        float canvasWidth = canvasRectTransform.rect.width;
    //        mapWidth = (canvasWidth / 2) / 100f;
    //    }
    //}
    //void FixedUpdate()
    //{
    //    // Get the horizontal input (left and right arrow keys or A/D keys)
    //    Debug.Log("Horizontal Input: " + Input.GetAxis("Horizontal"));

    //    float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

    //    // Only apply movement if there is actual input (x != 0)
    //    if (Mathf.Abs(x) > 0.01f) // A small threshold to ignore noise
    //    {
    //        // Move the satellite left or right
    //        Vector2 newPosition = rb.position + Vector2.right * x;
    //        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

    //        // Apply the movement
    //        rb.MovePosition(newPosition);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Asteroid")
    //    {

    //        // Disable player's collider to prevent multiple collisions
    //        GetComponent<Collider2D>().enabled = false;
    //        collisionFlag = true;

    //        lives--;
    //        UpdateLivesText();

    //        if (lives > 0)
    //        {
    //            StartCoroutine(ResetPlayerAndAsteroids());
    //        }
    //        else
    //        {
    //            ShowGameOver();
    //        }
    //    }

    //}
    //private IEnumerator ResetPlayerAndAsteroids()
    //{
    //    // Flash player before resetting
    //    StartCoroutine(FlashPlayer());


    //    // Reset player immediately
    //    transform.position = startPosition;

    //    // Clear and respawn asteroids after delay
    //    Object.FindFirstObjectByType<AsteroidSpawner>().ClearAsteroids();
    //    // Wait for the player to flash before resetting asteroids
    //    yield return new WaitForSeconds(1f);  // Add delay before respawning asteroids
    //    Object.FindFirstObjectByType<AsteroidSpawner>().SpawnAsteroids();

    //    // Re-enable player's collider after resetting
    //    GetComponent<Collider2D>().enabled = true;

    //}

    //// Coroutine to handle flashing the player
    //private IEnumerator FlashPlayer()
    //{
    //    for (int i = 0; i < 6; i++)  // Flash 3 times (on/off 6 times)
    //    {
    //        spriteRenderer.enabled = !spriteRenderer.enabled;  // Toggle sprite visibility
    //        yield return new WaitForSeconds(0.2f);  // Wait 0.2 seconds between flashes
    //    }

    //}

    //private void UpdateLivesText()
    //{
    //    livesText.text = "Lives: " + lives;  // Update UI text
    //}

    //private void ShowGameOver()
    //{
    //    gameOverMenu.SetActive(true);  // Show Game Over menu
    //    Time.timeScale = 0f;  // Pause the game
    //}
}
