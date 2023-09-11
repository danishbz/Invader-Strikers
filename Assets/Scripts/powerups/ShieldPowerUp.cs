using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SFXManager.instance.playShieldPU();
            CollectPowerUp();
        }
    }

    // Define the collection action here.
    private void CollectPowerUp()
    {
        // Access the HealthManager script and activate immunity effect
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        healthManager.ActivateImmunity();

        // Destroy the power-up GameObject.
        Destroy(gameObject);
    }
}
