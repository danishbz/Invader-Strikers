using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UltimateManager : MonoBehaviour
{
    public static UltimateManager instance;

    [SerializeField] private Slider ultSlider; //Slider
    [SerializeField] private int killLimit; //Kill Limit to Reach Ultimate
    [SerializeField] private GameObject activeUltTxtImg; //Ultimate Image

    private int killCount; //Kill Counter
    private bool isUltActive; //Check if Ult is Active

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //Default States
        activeUltTxtImg.SetActive(false);
        isUltActive = false;
        ultSlider.maxValue = killLimit;
        ultSlider.value = 0;
    }

    void Update()
    {
        //If kills is above the kill limit, ult is ready
        if (killCount >= killLimit)
        {
            isUltActive = true;
            activeUltTxtImg.SetActive(true);
        }
        else //Else if kills is lower than kill limit, ult is not ready
        {
            isUltActive = false;
            activeUltTxtImg.SetActive(false);
        }
    }
    // Increase kill counter
    public void increaseKillCount()
    {
        killCount++;
        ultSlider.value = killCount;
    }
    //Reset kill counter
    public void resetKillCount()
    {
        killCount = 0;
        ultSlider.value = killCount;
    }
    //Get Ultimate Status
    public bool getUltStatus()
    {
        return isUltActive;
    }
}
