using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // ... other variables and methods ...

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Activate the player's immunity
            PlayerHealthController.instance.ActivateImmunity();

            // Access the PlayerController script and activate the shield effect
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ActivateShieldEffect();
            }

            // Trigger any other desired power-up effects

            // Make the shieldEffect GameObject active
            playerController.ActivateShieldEffect();

            // Destroy the power-up GameObject after the collision
            Destroy(gameObject);
        }
    }
}
