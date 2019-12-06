using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    bool state;
    public GameObject ConfirmQuit;

    bool status;

    public void OpenPanel()
    {

        state = !state;
        panel.SetActive(state);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        status = !status;
        ConfirmQuit.SetActive(state);
    }
     public void Yesplz()
    {
       Application.Quit();
    }
       public void Noplz()
    {
        ConfirmQuit.SetActive(false);
    }

}