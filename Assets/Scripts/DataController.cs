using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
    private PlayerProgress playerProgress;
    public void Start() 
    {
        DontDestroyOnLoad(transform.gameObject);
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

    public void SubmitNewPlayerScoreAve(float newScore)
    {
        Debug.Log(newScore);
        Debug.Log(playerProgress.highestScoreAve);

        if(newScore > playerProgress.highestScoreAve)
        {
            playerProgress.highestScoreAve = newScore;
            Debug.Log("passed the new highscore");
            SavePlayerProgressAve();
        }
    }

    public void SubmitNewPlayerScoreDifficult(float newScore)
    {
        Debug.Log(newScore);
        Debug.Log(playerProgress.highestScoreDifficult);

        if(newScore > playerProgress.highestScoreDifficult)
        {
            playerProgress.highestScoreDifficult = newScore;
            Debug.Log("passed the new highscore");
            SavePlayerProgressDifficult();
        }
    }

     public float GetHighestPlayerScore()
    {
        Debug.Log("got the highscore");
        return playerProgress.highestScore;
    }

    public float GetHighestPlayerScoreAve()
    {
        Debug.Log("got the highscore Ave");
        return playerProgress.highestScoreAve;
    }

    public float GetHighestPlayerScoreDifficult()
    {
        Debug.Log("got the highscore Difficult");
        return playerProgress.highestScoreDifficult;
    }

    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if(PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetFloat("highestScore");
        }
    }

     private void LoadPlayerProgressAve()
    {
        playerProgress = new PlayerProgress();

        if(PlayerPrefs.HasKey("highestScoreAve"))
        {
            playerProgress.highestScoreAve = PlayerPrefs.GetFloat("highestScoreAve");
        }
    }

    private void LoadPlayerProgressDifficult()
    {
        playerProgress = new PlayerProgress();

        if(PlayerPrefs.HasKey("highestScoreDifficult"))
        {
            playerProgress.highestScoreDifficult = PlayerPrefs.GetFloat("highestScoreDifficult");
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetFloat("highestScore", playerProgress.highestScore);
    }

    private void SavePlayerProgressAve()
    {
        PlayerPrefs.SetFloat("highestScoreAve", playerProgress.highestScoreAve);
    }

    private void SavePlayerProgressDifficult()
    {
        PlayerPrefs.SetFloat("highestScoreDifficult", playerProgress.highestScoreDifficult);
    }

}