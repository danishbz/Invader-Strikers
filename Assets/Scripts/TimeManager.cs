using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    [SerializeField] private TextMeshProUGUI timerNum; //Timer Text
    private float timer; //Timer Time

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime; //Count Up timer
        timerNum.text = Mathf.Ceil(timer).ToString(); //Round up time and set as timer text
    }
    //Get Time
    public float getTime()
    {
        return Mathf.Ceil(timer);
    }
}
