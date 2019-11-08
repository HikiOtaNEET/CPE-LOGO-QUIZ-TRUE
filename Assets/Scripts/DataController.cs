using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
    private PlayerProgress playerProgress;
    public void Start() 
    {
        DontDestroyOnLoad(gameObject);
        LoadPlayerProgress();
        SceneManager.LoadScene("Start");

    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    public void SubmitNewPlayerScore(float newScore)
    {
        Debug.Log(newScore);
        Debug.Log(playerProgress.highestScore);
        if(newScore > playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;
            Debug.Log("passed the new highscore");
            SavePlayerProgress();
        }
    }

     public float GetHighestPlayerScore()
    {
        Debug.Log("got the highscore");
        return playerProgress.highestScore;
    }


    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if(PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetFloat("highestScore");
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetFloat("highestScore", playerProgress.highestScore);
    }

}