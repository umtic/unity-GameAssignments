using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {

    public float speed = 5.0f;
    public GameObject asteroid;

    private float maxHeight;

    private SpaceShipGameControllerScript gameController;

    // Use this for initialization
    void Start()
    {
        maxHeight = Camera.main.orthographicSize + 3.0f;
        gameController = FindObjectOfType<SpaceShipGameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
        if (transform.position.y < -maxHeight){
            if (gameObject.tag.Equals("AsteroidRed")){gameController.RemoveHealth(7);}
            if (gameObject.tag.Equals("AsteroidOrange")){gameController.RemoveHealth(3);}
            if(gameObject.tag.Equals("ShootingObject")){gameController.RemoveHealth(1);}
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Laser"))
        {
            if(gameObject.tag.Equals("AsteroidOrange")){
                gameController.AddScore(2);
                Instantiate(asteroid, transform.position, transform.rotation);
            }
            if(gameObject.tag.Equals("AsteroidRed")){
                gameController.AddScore(3);
                Instantiate(asteroid, transform.position, transform.rotation);
            }
            if(gameObject.tag.Equals("ShootingObject")){gameController.AddScore(1);}
            if(gameObject.tag.Equals("AsteroidGreen")){gameController.GameOver();}
            Destroy(gameObject);}
        if (other.tag.Equals("Player"))
        {
            if(gameObject.tag.Equals("AsteroidOrange")){gameController.AddScore(2);}
            if(gameObject.tag.Equals("AsteroidRed")){gameController.AddScore(3);}
            if(gameObject.tag.Equals("ShootingObject")){gameController.AddScore(1);}
            Destroy(gameObject);
        }
    }
}
