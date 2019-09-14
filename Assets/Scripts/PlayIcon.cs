using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayIcon : MonoBehaviour
{
    public void changemenuscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
