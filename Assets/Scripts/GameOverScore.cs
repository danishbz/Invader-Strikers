using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreNum;
    [SerializeField] private TextMeshProUGUI scoreNum;
    [SerializeField] private TextMeshProUGUI endHighScoreNum;
    [SerializeField] private TextMeshProUGUI endScoreNum;

    // Update is called once per frame
    void OnEnable()
    {
        int timer = (int)TimeManager.instance.getTime();
        ScoreManager.instance.UpdateScore(timer);
        endHighScoreNum.text = highScoreNum.text;
        endScoreNum.text = scoreNum.text;
    }
}
