using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] ballPrefabs;
    private Vector3[] spawnPositions = { new Vector3 { x = 3, y = 0.5f, z = 170 },
                         new Vector3 { x = 0, y = 0.5f, z = 170},
        new Vector3 { x = -3, y = 0.5f, z = 170}};

    [SerializeField] private Text remainingTimeText;
    [SerializeField] private Text playerScoreText;

    public int playerScore;
    public float remainingTime;
    public bool isGameActive;
    // Start is called before the first frame update
    void Awake()
    {
        startNewGame();  
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        Timer();
        UpdateTimer();
    }
    
    void startNewGame()
    {
        playerScore = 0;
        remainingTime = 30.0f;
        isGameActive = true;
        InvokeRepeating("SpawnBalls", 0, 0.7f);
    }
    void SpawnBalls()
    {
        if (isGameActive) {
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        int spawnLocIndex = Random.Range(0, spawnPositions.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPositions[spawnLocIndex], ballPrefabs[ballIndex].transform.rotation);
        }
    }

    void UpdateScore()
    {
        playerScoreText.text = "Score: " + playerScore;
    }

    void UpdateTimer()
    {
        remainingTimeText.text = "Time: " + Mathf.CeilToInt(remainingTime);
    }

    void Timer()
    {
        if (isGameActive && remainingTime >= 0){
            remainingTime -= Time.deltaTime;
        } else
        {
            isGameActive = false;
        }
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // IEnumerator 
}
