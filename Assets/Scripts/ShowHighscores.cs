using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class ShowHighscores : MonoBehaviour
{
    public Text easy;
    public Text average;
    public Text diff;
    
    private DataController dataController;
    private PlayerProgress playerProgress;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerProgress = new PlayerProgress();

        playerProgress.highestScore = PlayerPrefs.GetFloat("highestScore");
        playerProgress.highestScoreAve = PlayerPrefs.GetFloat("highestScoreAve");
        playerProgress.highestScoreDifficult = PlayerPrefs.GetFloat("highestScoreDifficult");

        easy.text = playerProgress.highestScore.ToString();
        average.text = playerProgress.highestScoreAve.ToString();
        diff.text = playerProgress.highestScoreDifficult.ToString();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
