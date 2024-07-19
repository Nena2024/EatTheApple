using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;



    public TextMeshProUGUI winText;
    public TextMeshProUGUI gameOver;

    public Button restartButton;
    public bool isGameActive = true;

    public int MaxScore = 0;
    private int score;

    public Text BestScore;
    public Text scoreText;

    public string bestPlayer;



    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Debug.Log("GameManager instance created.");
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager instance detected.");
            Destroy(gameObject);
        }
    }

    void Start()
    {

        if (KeepName.Instance != null)
        {

            isGameActive = true;

        }
    }
    private void Update()
    {
        {
            SaveDataManager.LoadScore();
            BestScore.text = " Best Score: " + bestPlayer + " : " + MaxScore;
        }
    }
    // Update is called once per frame

    public void UpdateScore(int scoreToAdd)
    {

        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        if (score >= MaxScore)
        {
            MaxScore = score;
            bestPlayer = KeepName.Instance.name;
            SaveDataManager.SaveScore();
            Debug.Log("saved");
        }
    }
    public void StartGame()
    {


        isGameActive = true;


    }
    public void GameOver()
    {
        isGameActive = false;
        gameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);


    }
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SaveDataManager.LoadScore();
        BestScore.text = " Best Score: " + bestPlayer + " : " + MaxScore;
    }

    //if the player wins the game 

    public void WinGame()
    {
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;

    }

}
