using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{

    public Text answerText;

    
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(string data)
    {
        answerText.text = data;
    }


    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerText.text);
    }
}