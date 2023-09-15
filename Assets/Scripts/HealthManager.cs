using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    [SerializeField] private float maxHealth, secToWait; //Maximum Player Health, Seconds to Wait After Death
    [SerializeField] private Slider healthSlider; //Slider
    [SerializeField] private GameObject shield, shieldIconUI; //Shield Effect and Shield Powerup UI
    [SerializeField] private float immunityDuration; //Immunity Duration, For Shield Powerup

    private float currentHealth; //Current Health
    private GameObject player; //Player Game Object
    private bool isImmune; //Check Immune

    private void Awake()
    {
        instance = this;

        player = GameObject.FindGameObjectWithTag("Player");
        //Default states
        isImmune = false;
        shield.SetActive(false);
        shieldIconUI.SetActive(false);
    }

    void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth; //Set slider max value
        healthSlider.value = currentHealth; //Set slider current value
    }

    public void ApplyDamage(float damageToTake)
    {
        //If player is not immune, player can be damaged
        if (!isImmune)
        {
            SFXManager.instance.playDamaged();
            currentHealth -= damageToTake;

            if (currentHealth <= 0)
            {
                Destroy(player);
                StartCoroutine(EndScreenCoroutine());
            }

            healthSlider.value = currentHealth;
        }
        else //Else player is immune and cannot be damaged
        {
            Debug.Log("Player is immune; no damage taken");
        }
    }

    //Wait for awhile before showing game over screen
    private IEnumerator EndScreenCoroutine()
    {
        yield return new WaitForSeconds(secToWait);
        GameManager.instance.GameOver();
    }

    //Activate immunity
    public void ActivateImmunity()
    {
        //If player is not immune, activate immunity
        if (!isImmune)
        {
            Immunity();
        }
        else //else cancal invoke and reactivate immunity again
        {
            CancelInvoke("DeactivateImmunity");
            Immunity();
        }
    }
    //Immunity
    private void Immunity()
    {
        isImmune = true;
        shield.SetActive(true);
        shieldIconUI.SetActive(true);
        Invoke("DeactivateImmunity", immunityDuration); //Call DeactivateImmunity after a duration ends
    }

    //Deactivate Immunity
    private void DeactivateImmunity()
    {
        isImmune = false;
        shield.SetActive(false);
        shieldIconUI.SetActive(false);
    }
    //Increase Health, For Heal Powerup
    public void IncreaseHealth(float healthToAdd)
    {
        currentHealth += healthToAdd;

        //Ensure health doesn't exceed the maximum value.
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        healthSlider.value = currentHealth;
    }

}
