using TMPro;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;


public class AsteroidSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject asteroid;
    //private Satellite player;
    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 3f;
    private List<GameObject> activeAsteroids = new List<GameObject>();

    //private float currentGravity = 0.2f;  // Starting gravity value
    //public int currentLevel = 0;  // Track the current level
    //public TMP_Text levelsText;  // UI Text to display the current level
    //public GameObject levelCapMenu;  // Level Cap UI panel for "Congratulations"
    //private Camera mainCamera;
    //private float screenHeight;

    //private void Start()
    //{
    //    UpdateLevelText();
    //    levelCapMenu.SetActive(false);
    //    player = Object.FindFirstObjectByType<Satellite>();
    //    mainCamera = Camera.main;

    //    // Calculate screen height from the camera's viewport
    //    screenHeight = mainCamera.orthographicSize;
    //    AdjustTimeBetweenWaves();  // Adjust the wave timing initially
    //}
    private void Awake()
    {
        timeToSpawn = 1;
        timeBetweenWaves = 3;
    }

    private void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnAsteroids();
            //LevelTracker();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    //// Calculate the time it takes for an asteroid to fall off the screen
    //private void AdjustTimeBetweenWaves()
    //{
    //    // Calculate the distance from the spawn point to just below the screen
    //    float spawnHeight = spawnPoints[0].position.y;  // Assuming asteroids spawn at the same height
    //    float distanceToFall = (spawnHeight + screenHeight) / 2f;  // Distance from spawn to just below the screen

    //    // Calculate fall time based on gravity and distance
    //    float fallTime = Mathf.Sqrt(0.6f * distanceToFall / currentGravity);

    //    // Set timeBetweenWaves based on the calculated fall time
    //    timeBetweenWaves = fallTime;
    //}

    public void SpawnAsteroids()
    {

        ClearAsteroids(1);
        //AdjustTimeBetweenWaves();  // Adjust the wave timing for the current gravity

        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                GameObject newAsteroid = Instantiate(asteroid, spawnPoints[i].position, Quaternion.identity);
                //newAsteroid.GetComponent<Rigidbody2D>().gravityScale = currentGravity;
                activeAsteroids.Add(newAsteroid);
            }
        }

    }

    public void ClearAsteroids(int num)
    {
        foreach (GameObject asteroids in activeAsteroids)
        {
            if (num == 1) {
                if (asteroids.transform.position.y < -2f)
                {
                    Destroy(asteroids);
                }
            }
            else if (num == 2)
            {
                if (asteroids != null)
                {
                    Destroy(asteroids);
                }
            }
        }
        activeAsteroids.Clear();
      
    }

    //private void ShowLevelCap()
    //{
    //    levelCapMenu.SetActive(true);  // Show the "Congratulations" menu
    //    Time.timeScale = 0f;  // Pause the game
    //}

    //private void UpdateLevelText()
    //{
    //    int newLvl = currentLevel - 1;
    //    levelsText.text = "Level: " + newLvl;
    //}

    //private void LevelTracker()
    //{
    //    if (!player.collisionFlag)
    //    {
    //        if (currentLevel < 20)
    //        {
    //            currentLevel++;
    //            UpdateLevelText();
    //            currentGravity += 0.025f;
    //        }
    //        else if (currentLevel == 20)
    //        {
    //            currentLevel++;
    //            UpdateLevelText();
    //            ShowLevelCap();
    //        }
    //    }

    //    player.collisionFlag = false;
    //}
}
