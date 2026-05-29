using UnityEngine;
using System.Collections;

public enum BreakoutGameState { playing, won, lost };

public class BreakoutGame : MonoBehaviour
{
    public static BreakoutGame SP;

    public Transform ballPrefab , pickupBall, pickupSmall, pickupLarge;

    private int totalBlocks;
    private int blocksHit;
    private BreakoutGameState gameState;
    private AudioSource audio;
    public AudioClip clip1,clip2;
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    void Awake()
    {
        SP = this;
        blocksHit = 0;
        gameState = BreakoutGameState.playing;
        totalBlocks = GameObject.FindGameObjectsWithTag("Pickup").Length;
        Time.timeScale = 1.0f;
        SpawnBall();
    }

    public void SpawnBall()
    {
        Instantiate(ballPrefab, new Vector3(1.81f, 1.0f , 9.75f), Quaternion.identity);
    }

    void OnGUI(){
    
        GUILayout.Space(10);
        GUILayout.Label("  Hit: " + blocksHit + "/" + totalBlocks);

        if (gameState == BreakoutGameState.lost)
        {
            GUILayout.Label("You Lost!");
            if (GUILayout.Button("Try again"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        else if (gameState == BreakoutGameState.won)
        {
            GUILayout.Label("You won!");
            if (GUILayout.Button("Play again"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void HitBlock()
    {
        blocksHit++;
        int luck = Random.Range(1,21);
        if(luck == 20)
        {
            Instantiate(pickupBall, new Vector3(1.81f, 1.0f , 9.75f), Quaternion.identity);
        }
        else if(luck == 19)
        {
            Instantiate(pickupSmall, new Vector3(1.81f, 1.0f , 9.75f), Quaternion.identity);
        }
        else if(luck == 18)
        {
            Instantiate(pickupLarge, new Vector3(1.81f, 1.0f , 9.75f), Quaternion.identity);
        }
        //For fun:
        //if (blocksHit%10 == 0) //Every 10th block will spawn a new ball
        //{
        //    SpawnBall();
        //}

        
        if (blocksHit >= totalBlocks)
        {
            WonGame();
        }
    }

    public void WonGame()
    {
        audio.PlayOneShot(clip2,1);
        Time.timeScale = 0.0f; //Pause game
        gameState = BreakoutGameState.won;
    }

    public void LostBall()
    {
        int ballsLeft = GameObject.FindGameObjectsWithTag("Player").Length;
        if(ballsLeft<=1){
            //Was the last ball..
            SetGameOver();
        }
    }

    public void SetGameOver()
    {
        audio.PlayOneShot(clip1,1);
        Time.timeScale = 0.0f; //Pause game
        gameState = BreakoutGameState.lost;
    }
}
