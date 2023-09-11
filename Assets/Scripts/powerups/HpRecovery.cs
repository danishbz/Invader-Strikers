using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpRecovery : MonoBehaviour
{
    public float healthToAdd = 1f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthManager healthManager = HealthManager.instance;
            if (healthManager != null)
            {
                healthManager.IncreaseHealth(healthToAdd);
            }
            Destroy(gameObject);
        }
    }
}
