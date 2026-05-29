using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
	void Awake () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
	}
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= -3){            
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter (Collision other) {
        if(other.gameObject.name=="Paddle")
        {
            if(gameObject.name.StartsWith("PickupBall"))
            {
                BreakoutGame.SP.SpawnBall();
            }
            else if(gameObject.name.StartsWith("PickupSmall"))
            {
                other.gameObject.transform.localScale = new Vector3(5 , 1 , 1);
                other.gameObject.GetComponent<Paddle>().moveSpeed = 30;
            }
            else if (gameObject.name.StartsWith("PickupLarge"))
            {
                other.gameObject.transform.localScale = new Vector3(20 , 1 , 1);
                other.gameObject.GetComponent<Paddle>().moveSpeed = 7.5f;
            }
            Destroy(gameObject);
        }

	}
}
