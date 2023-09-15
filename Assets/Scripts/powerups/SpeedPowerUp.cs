using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SFXManager.instance.playSpeedPU();
            player = collision.gameObject;
            CollectPowerUp();
        }
    }

    // Define the collection action here.
    private void CollectPowerUp()
    {
        // Access the PlayerController script and apply speed increase
        PlayerController playerCon = player.GetComponent<PlayerController>();
        playerCon.IncreaseSpeed();

        // Destroy the power-up GameObject.
        Destroy(gameObject);
    }
}