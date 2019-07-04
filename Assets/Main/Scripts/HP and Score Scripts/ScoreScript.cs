using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text textBoxScore;

    public int score;
    private static int totalScore; 

    void Start()
    {
        score = 0;
        ChangeScoreText();
    }

    //public void Update()
    //{
    //    textBoxScore.text = "Score: " + score;
    //}

    public void ChangeScoreText()
    {
        textBoxScore.text = "Score: " + score;
    }

    public void ChangeScoreNumber (int number)
    {
        score += number;
        LoadPoints1.totalPoints += number;
        ChangeScoreText();
    }
}
