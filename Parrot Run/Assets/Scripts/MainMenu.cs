using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Play Button Control
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Options Button Control
    public void OpenOptionsMenu()
    {

    }

    //Quit Button Control
    public void QuitGame()
    {

    }
}
