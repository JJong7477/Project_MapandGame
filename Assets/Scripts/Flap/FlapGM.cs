using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FlapGM : MonoBehaviour
{
    static FlapGM gameManager;

    public static FlapGM Instance
    {
        get { return gameManager; }
    }
    public FlapUI flapUI;
    public GameObject startUI;
    private int currentScore = 0;


    private void Awake()
    {
        gameManager = this;
        flapUI = FindObjectOfType<FlapUI>();
        Time.timeScale = 0;
        
    }


    private void Start()
    {
        flapUI.UpdateScore(0);
    }

    public void GameStart()
    {
        startUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        //Debug.Log("Game Over");
        flapUI.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        flapUI.UpdateScore(currentScore);
        //Debug.Log("Score: " + currentScore);
    }
}
