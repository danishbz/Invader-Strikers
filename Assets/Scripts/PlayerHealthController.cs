using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD:Assets/Scripts/HealthManager.cs
<<<<<<< HEAD:Assets/Scripts/PlayerHealthController.cs

public class PlayerHealthController : MonoBehaviour
=======
public class HealthManager : MonoBehaviour
>>>>>>> 34ca63dac42326b8c8198d8e4988a810bb59aefc:Assets/Scripts/HealthManager.cs
=======
public class PlayerHealthController : MonoBehaviour
>>>>>>> parent of 47c7d32 (GameOver screen, Timer, score, highscore):Assets/Scripts/PlayerHealthController.cs
{
    public static PlayerHealthController instance;

    [SerializeField] private float maxHealth;
    [SerializeField] private Slider healthSlider;

    private float currentHealth;
    private GameObject player;

    // New variables for immunity system (power up)
    private float immunityDuration = 5f; // Duration of immunity after colliding with a power-up
    private bool isImmune = false;

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void ApplyDamage(float damageToTake)
    {
        // Check if the player is immune before applying damage
        if (!isImmune)
        {
<<<<<<< HEAD:Assets/Scripts/HealthManager.cs
<<<<<<< HEAD:Assets/Scripts/PlayerHealthController.cs
            Debug.Log("Damage taken");
            currentHealth -= damageToTake;
=======
            Destroy(player);
            StartCoroutine(EndScreenCoroutine());
            //player.SetActive(false);
=======
            player.SetActive(false);
>>>>>>> parent of 47c7d32 (GameOver screen, Timer, score, highscore):Assets/Scripts/PlayerHealthController.cs
        }
>>>>>>> 34ca63dac42326b8c8198d8e4988a810bb59aefc:Assets/Scripts/HealthManager.cs

            if (currentHealth <= 0)
            {
                player.SetActive(false);
            }

            healthSlider.value = currentHealth;
        }
        else
        {
            Debug.Log("Player is immune; no damage taken");
        }
    }


    // Method to activate immunity
    public void ActivateImmunity()
    {
        isImmune = true;
        Invoke("DeactivateImmunity", immunityDuration);
    }

    // Method to deactivate immunity
    private void DeactivateImmunity()
    {
        isImmune = false;
    }
}
