using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetmo : MonoBehaviour
{
    private PlayerProgress playerProgress;
    
    public void resetHighscore(){
        playerProgress.highestScore = 0;
        playerProgress.highestScoreAve = 0;
        playerProgress.highestScoreDifficult = 0;

        PlayerPrefs.SetFloat("highestScore", playerProgress.highestScore);
        PlayerPrefs.SetFloat("highestScoreAve", playerProgress.highestScoreAve);
        PlayerPrefs.SetFloat("highestScoreDifficult", playerProgress.highestScoreDifficult);
    }
}
