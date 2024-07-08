using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI gameOver;
    public Button restartButton;
    public bool isGameActive = true;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // updating score 
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    // setting the starting of the game 
    public void StartGame()
    {

        isGameActive = true;
        score = 0;
        UpdateScore(0);
       
    }
    // if the player loses the game 
    public void GameOver()
    {
        isGameActive = false;
        gameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        


    }
    //if the player loses the restart button will change the scene 
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //if the player wins the game 
     
    public void WinGame()
    {
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        
    }
    
}
