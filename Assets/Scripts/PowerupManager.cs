using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager instance;
    [SerializeField] GameObject[] PUUIArr; //Powerup UI Array

    private void Awake()
    {
        instance = this;
        foreach (GameObject i in PUUIArr)
        {
            i.SetActive(false);
        }
    }

    public void showPUUI(string powerup)
    {
        if (powerup == "shield")
        {
            PUUIArr[0].SetActive(true);
        }
        else
        {
            PUUIArr[1].SetActive(true);
        }
    }

    public void hidePUUI(string powerup)
    {
        if (powerup == "shield")
        {
            PUUIArr[0].SetActive(false);
        }
        else
        {
            PUUIArr[1].SetActive(false);
        }
    }
}
