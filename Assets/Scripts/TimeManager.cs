using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    [SerializeField] private TextMeshProUGUI timerNum;
    private float timer;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        timerNum.text = Mathf.Ceil(timer).ToString();
    }

    public float getTime()
    {
        return Mathf.Ceil(timer);
    }
}
