using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpaceShipGameControllerScript : MonoBehaviour {


    public GameObject AsteroidPrefab;
    public GameObject BluePickup;
    public GameObject AsteroidOrange;
    public GameObject AsteroidRed;
    public GameObject AsteroidGreen;
    

    private float maxWidth;
    private float maxHeight;

    public float asteroidPeriod = 1.5f;

    private int score = 0;
    private int health = 100;
    private bool showResetButton = false;

    // Use this for initialization
    void Start()
    {
        maxWidth = Camera.main.orthographicSize * Camera.main.aspect - 0.6f;
        maxHeight = Camera.main.orthographicSize - 1.0f;

        InvokeRepeating("CreateAsteroid", 1.0f, asteroidPeriod);

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void CreateAsteroid()
    {
        if (Random.Range(1, 21) > 18)
        {
            Instantiate(BluePickup, new Vector3(
                Random.Range(-maxWidth, maxWidth),
                maxHeight + 3.0f,
                0.0f
            ), Quaternion.identity);
        }
        else if(Random.Range(1 , 19) < 3 && Time.time > 10)
        {
            Instantiate(AsteroidOrange, new Vector3(
                Random.Range(-maxWidth, maxWidth),
                maxHeight + 3.0f,
                0.0f
            ), Quaternion.identity);
        }
        else if(Random.Range(3 , 19) < 5 && Time.time > 10)
        {
            Instantiate(AsteroidGreen, new Vector3(
                Random.Range(-maxWidth, maxWidth),
                maxHeight + 3.0f,
                0.0f
            ), Quaternion.identity);
        }
        else if(Random.Range(5 , 19) < 7 && Time.time > 20)
        {
            Instantiate(AsteroidRed, new Vector3(
                Random.Range(-maxWidth, maxWidth),
                maxHeight + 3.0f,
                0.0f
            ), Quaternion.identity);
        }
        else
        {
            Instantiate(AsteroidPrefab, new Vector3(
                Random.Range(-maxWidth, maxWidth),
                maxHeight + 3.0f,
                0.0f
            ), Quaternion.identity);
        }

    }

    public void AddScore(int points)
    {
        score += points;
    }
    public void RemoveHealth(int points)
    {
        health -= points;
    }

    public void GameOver()
    {
        showResetButton = true;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score : " + score);
        GUI.Label(new Rect(10, 40, 100, 40), "Planet Health : " + health);

        if (showResetButton)
        {
            if (GUI.Button(new Rect(Camera.main.pixelWidth / 2 - 40, Camera.main.pixelHeight / 2 - 15, 80, 30), "Try again"))
            {
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
            }
        }
    }


}
