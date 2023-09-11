using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    [SerializeField] private float healthToAdd; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SFXManager.instance.playHealPU();
            HealthManager healthManager = HealthManager.instance;
            if (healthManager != null)
            {
                healthManager.IncreaseHealth(healthToAdd);
            }
            Destroy(gameObject);
        }
    }
}
