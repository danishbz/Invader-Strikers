using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedIncreasePercentage = 0.1f; // 1% increase in speed
    public float maxSpeed = 6f; // Maximum speed

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Get the PlayerController script of the player
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Apply the speed increase from the SpeedPowerUp
                float newSpeed = playerController.moveSpeed + playerController.moveSpeed * speedIncreasePercentage;

                // Cap the speed to the maximum value
                if (newSpeed > maxSpeed)
                {
                    newSpeed = maxSpeed;
                }

                // Update the player's move speed
                playerController.moveSpeed = newSpeed;

                // Destroy the Speed PowerUp GameObject
                Destroy(gameObject);
            }
        }
    }
}
