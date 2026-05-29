using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float maxVelocity = 20;
    public float minVelocity = 15;
    private AudioSource audio;
    public AudioClip clip;

	void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    void Awake () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -18);
	}

	void Update () {
        Vector3 velocity = GetComponent<Rigidbody>().linearVelocity;
        //Make sure we stay between the MAX and MIN speed.
        float totalVelocity = velocity.magnitude;
        if(totalVelocity>maxVelocity){
            float tooHard = totalVelocity / maxVelocity;
            velocity /= tooHard;
        }
        else if (totalVelocity < minVelocity)
        {
            float tooSlowRate = totalVelocity / minVelocity;
            velocity /= tooSlowRate;
        }
        if(velocity.z < 10 && velocity.z > 0)
        {
            velocity.z = 10;
        }
        if(velocity.z > -10 && velocity.z < 0)
        {
            velocity.z = -10;
        }
        GetComponent<Rigidbody>().linearVelocity = velocity;
        //Is the ball below -3? Then we're game over.
        if(transform.position.z <= -3){            
            BreakoutGame.SP.LostBall();
            Destroy(gameObject);
        }
	}
    void OnCollisionEnter()
    {
        audio.PlayOneShot(clip,1);
    }
}
