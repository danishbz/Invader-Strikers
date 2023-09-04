using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD:Assets/Scripts/PlayerHealthController.cs

public class PlayerHealthController : MonoBehaviour
=======
public class HealthManager : MonoBehaviour
>>>>>>> 34ca63dac42326b8c8198d8e4988a810bb59aefc:Assets/Scripts/HealthManager.cs
{
    public static HealthManager instance;

    [SerializeField] private float maxHealth, secToWait;
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
<<<<<<< HEAD:Assets/Scripts/PlayerHealthController.cs
            Debug.Log("Damage taken");
            currentHealth -= damageToTake;
=======
            Destroy(player);
            StartCoroutine(EndScreenCoroutine());
            //player.SetActive(false);
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
    private IEnumerator EndScreenCoroutine()
    {
        Debug.Log("Started Coroutine");
        yield return new WaitForSeconds(secToWait);
        GameManager.instance.GameOver();
    }
}
