using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunUlt : MonoBehaviour
{
    [SerializeField] private GameObject shotgunEffect; //Shotgun effect
    [SerializeField] private float ultDuration;

    private bool pressedOnce;
    private void Awake()
    {
        shotgunEffect.SetActive(false);
    }
    private void Update()
    {
        bool isUltActive = UltimateManager.instance.getUltStatus();
        if (Input.GetKeyDown("x") && isUltActive && !pressedOnce)
        {
            pressedOnce = true;
            activateUlt();
        }
    }
    private void activateUlt()
    {
        shotgunEffect.SetActive(true);
        SFXManager.instance.playShotgunUlt(true);
        StartCoroutine(resetKillCoroutine());
    }
    private IEnumerator resetKillCoroutine()
    {
        shotgunEffect.SetActive(true);
        
        yield return new WaitForSeconds(ultDuration);
        SFXManager.instance.playShotgunUlt(false);
        shotgunEffect.SetActive(false);
        UltimateManager.instance.resetKillCount();
        pressedOnce = false;
    }
}
