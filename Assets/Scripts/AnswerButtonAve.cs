using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButtonAve : MonoBehaviour
{

    public Text answerText;

    private GameControllerAve gameControllerAve;

    // Use this for initialization
    void Start()
    {
        gameControllerAve = FindObjectOfType<GameControllerAve>();
    }

    public void Setup(string data)
    {
        answerText.text = data;
    }


    public void HandleClick()
    {
        gameControllerAve.AnswerButtonClicked(answerText.text);
    }
}