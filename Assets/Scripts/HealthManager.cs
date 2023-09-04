using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    [SerializeField] private float maxHealth, secToWait;
    [SerializeField] private Slider healthSlider;

    private float currentHealth;
    private GameObject player;

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
        Debug.Log("Damage taken");
        currentHealth -= damageToTake;

        if(currentHealth <= 0)
        {
            Destroy(player);
            StartCoroutine(EndScreenCoroutine());
            //player.SetActive(false);
        }

        healthSlider.value = currentHealth;
    }
    private IEnumerator EndScreenCoroutine()
    {
        Debug.Log("Started Coroutine");
        yield return new WaitForSeconds(secToWait);
        GameManager.instance.GameOver();
    }
}
