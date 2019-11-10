using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    bool state;

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
        Application.Quit();
    }


}