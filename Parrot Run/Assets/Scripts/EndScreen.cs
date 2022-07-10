using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
    public static bool foundParrot = false;
    public GameObject EndScreenUI;
    public GameObject HP;
    
    private void Update()
    {
        if (foundParrot == true)
        {
            //Wait a second before showing the end screen
            Score.instance.ShowWinningScore();
            Invoke("showEndScreen", 1.5f);
        }
    }

    public void showEndScreen()
    {
        HP.SetActive(false);
        EndScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

   


    public void LoadMenu(int sceneID)
    {
        EndScreenUI.SetActive(false);
        HP.SetActive(true);
        foundParrot = false;
        Time.timeScale = 1f;

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
