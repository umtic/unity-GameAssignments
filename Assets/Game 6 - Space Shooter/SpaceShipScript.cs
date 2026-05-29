using UnityEngine;
using System.Collections;

public class SpaceShipScript : MonoBehaviour {


    private SpriteRenderer sr;
    public float speed = 15.0f;
    public GameObject LaserPrefab;

    private float maxWidth;
    private float maxHeight;

    private SpaceShipGameControllerScript gameController;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        maxWidth = Camera.main.orthographicSize * Camera.main.aspect - 0.6f;
        maxHeight = Camera.main.orthographicSize - 1.0f;

        gameController = FindObjectOfType<SpaceShipGameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f; 
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);

        float clampedX = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        float clampedY = Mathf.Clamp(targetPosition.y, -maxHeight, maxHeight);
        Vector3 finalTarget = new Vector3(clampedX, clampedY, 0f);

        transform.position = Vector3.MoveTowards(
            transform.position, 
            finalTarget, 
            speed * Time.deltaTime
            );

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(LaserPrefab, new Vector3(transform.position.x, transform.position.y + 1.0f, 0.0f), Quaternion.identity);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("BluePickup"))
        {
            sr.color = Color.blue;
        }
        else
        {
            if(sr.color == Color.blue)
            {sr.color = Color.white;}
            else
            {
                gameController.GameOver();
                Destroy(gameObject);
            }

        }
    }
}
