using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private bool isCollected = false;
    private float effectDuration = 5f; // Duration of the power-up effect in seconds
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Shield Taken");
        if (collision.CompareTag("Player") && !isCollected)
        {
            player = collision.gameObject;
            // Perform the collection action here.
            CollectPowerUp();

            // Mark the power-up as collected.
            isCollected = true;

            // Deactivate the effect after the duration.
            DeactivateEffect();
        }
    }

    // Define the collection action here.
    private void CollectPowerUp()
    {
        // You can implement the power-up effect here.
        // Access the PlayerController script and activate the shield effect
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ActivateShieldEffect();
            Debug.Log("Shield effect activated!");
        }
        // Find the HealthManager script in the scene
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        if (healthManager != null)
        {
            // Activate immunity through the HealthManager
            healthManager.ActivateImmunity();
            Debug.Log("Immunity activated!");
        }

        // Destroy the power-up GameObject.
        Destroy(gameObject);
    }

    // Deactivate the effect after the specified duration.
    private void DeactivateEffect()
    {
        // Revert the effect or clean up any changes made by the power-up.
        // For example, if you increased the player's speed, you can reset it here.

        // Destroy the power-up GameObject or perform any cleanup.
        Destroy(gameObject, effectDuration); // Destroy the object after the duration.
    }
}
