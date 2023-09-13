using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UltimateManager : MonoBehaviour
{
    public static UltimateManager instance;

    [SerializeField] private Slider ultSlider;
    [SerializeField] private int killLimit;
    [SerializeField] private GameObject activeUltTxtImg;

    private int killCount;
    private bool isUltActive;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        activeUltTxtImg.SetActive(false);
        isUltActive = false;
        ultSlider.maxValue = killLimit;
        ultSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (killCount >= killLimit)
        {
            isUltActive = true;
            activeUltTxtImg.SetActive(true);
        }
        else
        {
            isUltActive = false;
            activeUltTxtImg.SetActive(false);
        }
    }
    public void increaseKillCount()
    {
        killCount++;
        ultSlider.value = killCount;
    }
    public void resetKillCount()
    {
        killCount = 0;
        ultSlider.value = killCount;
    }
    public bool getUltStatus()
    {
        return isUltActive;
    }
}
