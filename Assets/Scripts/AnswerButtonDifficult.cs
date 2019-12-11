using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButtonDifficult : MonoBehaviour
{

    public Text answerText;

    private GameControllerDifficult gameControllerDifficult;

    // Use this for initialization
    void Start()
    {
        gameControllerDifficult = FindObjectOfType<GameControllerDifficult>();
    }

    public void Setup(string data)
    {
        answerText.text = data;
    }


    public void HandleClick()
    {
        gameControllerDifficult.AnswerButtonClicked(answerText.text);
    }
}