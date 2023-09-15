using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreNum; //Highscore from UI
    [SerializeField] private TextMeshProUGUI scoreNum; //Score from UI
    [SerializeField] private TextMeshProUGUI endHighScoreNum; //Game Over Highscore Text
    [SerializeField] private TextMeshProUGUI endScoreNum; //Game Over Score Text

    // Update is called once per frame
    void OnEnable()
    {
        int timer = (int)TimeManager.instance.getTime(); //Get time from Time Manager
        ScoreManager.instance.UpdateScore(timer); //Add timer into score
        //Set Game Over score texts as the UI score texts
        endHighScoreNum.text = highScoreNum.text; 
        endScoreNum.text = scoreNum.text;
    }
}
