using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI highScoreTxt; //Highscore Text
    [SerializeField] private TextMeshProUGUI scoreTxt; //Score Text

    private int score; //Score

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreTxt.text = score.ToString(); //Update UI
        highScoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //Get player highscore from player preferences

        UpdateHighScore();
    }
    //Update Highscore
    private void UpdateHighScore()
    {
        //If current score is higher than highscore, update highscore
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreTxt.text = score.ToString(); //Update UI
        }
    }
    //Update score
    public void UpdateScore(int points)
    {
        score += points;
        scoreTxt.text = score.ToString(); //Update UI
        UpdateHighScore();
    }
}

