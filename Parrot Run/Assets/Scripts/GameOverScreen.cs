using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject GameOverUI;
    private void Update()
    {
        if (gameOver == true)
        {
            //Wait one Second befor showing the game over screen (so death animation can play)
            Score.instance.ShowFinalScore();
            Invoke("showGameOverScreen", 1.5f);
        }
    }

    public void showGameOverScreen()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry(int sceneID)
    {
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
        gameOver = false;
        Score.instance.coinImage.enabled = true;
        PlayerCollision.pc.h1.enabled = true;
        PlayerCollision.pc.h2.enabled = true;
        PlayerCollision.pc.h3.enabled = true;
        SceneManager.LoadScene(sceneID);
    }


    public void LoadMenu(int sceneID)
    {
        Time.timeScale = 1f;
        gameOver = false;
        Score.instance.coinImage.enabled = true;
        PlayerCollision.pc.h1.enabled = true;
        PlayerCollision.pc.h2.enabled = true;
        PlayerCollision.pc.h3.enabled = true;
        SceneManager.LoadScene(sceneID);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
