using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt;

    private int score;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreTxt.text = score.ToString();
        highScoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreTxt.text = score.ToString();
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreTxt.text = score.ToString();
        UpdateHighScore();
    }
}

