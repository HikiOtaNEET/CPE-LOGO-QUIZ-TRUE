﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using System.Linq;

public class GameControllerAve : MonoBehaviour
{
    private logos[] logo;

    public Text scoreDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Text timeRemainingDisplayText;
    public GameObject logoarea;
    public Transform answerButtonParent;
    public GameObject roundEndDisplay;
    public Text highScoreDisplay;
    public Text status;
    public Text correctAnswer;
    public GameObject showAnswer;

    string path;
    string jsonString;
    string[] logoitem;
    string target;
    string choice;
    public string[] chosenlogos = new string[10];
    public string[] button = new string[4];
    public string[] temp = new string[4];

    private DataController dataController;
    private RoundData currentRoundData;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private float playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        timeRemaining = currentRoundData.timeLimitInSeconds;
        currentRoundData.pointsAddedForCorrectAnswer = 100;

        //jsonString = File.ReadAllText("Assets/Scripts/directoryAve.json");
        //logos items = JsonUtility.FromJson<logos>(jsonString);  //load JSON file

        //logoitem = items.easy;
        TextAsset w = Resources.Load<TextAsset>("directoryAve");
        JSONObject jSONObject = (JSONObject)JSON.Parse(w.text);
        logoitem = new string[jSONObject["easy"].Count];
        for (int i = 0; i < jSONObject["easy"].Count; i++)
            logoitem[i] = jSONObject["easy"][i];

        Debug.Log(logoitem);

        Debug.Log("checkpoint 2");

        playerScore = 0;
        questionIndex = 0;
        scoreDisplayText.text = playerScore.ToString();

        logopicker();

        ShowQuestion();
        isRoundActive = true;






    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();

        timeRemaining = 8;

        path = "Sprites/Average/" + chosenlogos[questionIndex]; // put in pathpp
        logoarea.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);

        Debug.Log("You are at question no. " + (questionIndex + 1));
        Debug.Log(chosenlogos[questionIndex]);

        choicepicker();

        for (int i = 0; i < 4; i++)
        {

            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButtonAve answerButton = answerButtonGameObject.GetComponent<AnswerButtonAve>();
            answerButton.Setup(button[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    private void logopicker()
    {

        for (int x = 0; x < 10; x++)
        {
            do
            {
                target = logoitem[UnityEngine.Random.Range(0, 27)];
            }
            while (chosenlogos.Contains(target) == true);

            chosenlogos[x] = target; //random item in the dir
            Debug.Log("chosen/" + target);


        }
    }

    private void choicepicker()
    {
        for (int z = 0; z < 4; z++)
        {
            do
            {
                choice = logoitem[UnityEngine.Random.Range(0, 27)];
            }
            while (button.Contains(choice) == true || choice == chosenlogos[questionIndex]);
            button[z] = choice;
        }
        button[Random.Range(0, 3)] = chosenlogos[questionIndex];

    }
    public void AnswerButtonClicked(string answerText)
    {
        if (answerText == chosenlogos[questionIndex])
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            playerScore += (Mathf.Round(timeRemaining) * 10);
            scoreDisplayText.text = playerScore.ToString();
            status.text = "Correct!";
            status.color = new Color(0.1110716f, 0.6037736f, 0.1562739f, 1.0f);
            correctAnswer.text = chosenlogos[questionIndex];
            StartCoroutine(showtime());
            timeRemaining = 2f;
        }
        else
        {
            status.text = "Wrong!";
            status.color = Color.red;
            correctAnswer.text = chosenlogos[questionIndex];
            StartCoroutine(showtime());
            timeRemaining = 2f;
        }

    }

    public void EndRound()
    {
        isRoundActive = false;
        dataController.SubmitNewPlayerScoreAve(playerScore);
        highScoreDisplay.text = dataController.GetHighestPlayerScoreAve().ToString();


        logoarea.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = Mathf.Round(timeRemaining).ToString();
    }

    IEnumerator showtime()
    {
        showAnswer.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        showAnswer.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                questionIndex++;
                ShowQuestion();
            }

            if (10 > questionIndex + 1)
            {
                Debug.Log("Proceed");
            }
            else
            {
                EndRound();
            }

        }
    }
}