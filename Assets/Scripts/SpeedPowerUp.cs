using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] private float speedIncreasePercentage = 0.05f; // 5% speed increase by default
    private bool isApplied = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isApplied) return; // Ensure the power-up can only be applied once

        if (collision.CompareTag("Player"))
        {
            // Access the PlayerController script
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Calculate the new speed based on the percentage increase
                float originalSpeed = playerController.moveSpeed;
                float newSpeed = originalSpeed * (1 + speedIncreasePercentage);

                // Cap the new speed at a maximum of 10 (or any other desired value)
                newSpeed = Mathf.Clamp(newSpeed, 0f, 6f); // Change 10f to your desired maximum speed

                // Apply the new speed to the player
                playerController.moveSpeed = newSpeed;

                // Trigger any other desired power-up effects

                // Mark the power-up as applied
                isApplied = true;

                // Destroy the power-up GameObject after the collision
                Destroy(gameObject);
            }
        }
    }
}
