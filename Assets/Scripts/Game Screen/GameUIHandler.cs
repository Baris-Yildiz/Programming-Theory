using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIHandler : DisplayBestScore
{
    public static GameUIHandler Instance;
    public GameObject gameOverScreen;

    void Start()
    {
        base.Start();
        Instance = this;
    }

    public void EndGame()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
