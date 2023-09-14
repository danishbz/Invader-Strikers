using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private float health = 1f; // Enemy Health
    [SerializeField] private int points; // Enemy Points
    [SerializeField] private GameObject[] powerupArr; //Powerup Array
    [SerializeField] private Material whitenMat; // Whiten sprite material
    private float dropChance = 5f; // 5% chance to drop a power-up
    private SpriteRenderer spriteRenderer;
    private Material originalMat;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMat = spriteRenderer.material;
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        spriteRenderer.material = whitenMat;
        StartCoroutine(WaitOneFrame());
        if (health <= 0)
        {
            ScoreManager.instance.UpdateScore(points); //Update score
            StartCoroutine(WaitOneFrameDeath());
        }
    }

    private void DropPowerup()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= dropChance) //Drop chance rng
        {
            SFXManager.instance.playItemDrop();

            //Randomize powerup
            float powerUpRandomValue = Random.Range(0f, 1f);

            if (powerUpRandomValue < 0.35f)
            {
                Instantiate(powerupArr[0], transform.position, Quaternion.identity);
            }
            else if (powerUpRandomValue < 0.7f)
            {
                Instantiate(powerupArr[1], transform.position, Quaternion.identity);
            }
            else if (powerUpRandomValue < 0.95f)
            {
                Instantiate(powerupArr[3], transform.position, Quaternion.identity); // health restore powerup
            }
            else
            {
                Instantiate(powerupArr[2], transform.position, Quaternion.identity); // destroyer powerup
            }
        }
    }

    private IEnumerator WaitOneFrame()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material = originalMat; //Change back to original material
    }
    private IEnumerator WaitOneFrameDeath()
    {
        yield return new WaitForSeconds(0.1f);
        DropPowerup(); //Drop powerup
        UltimateManager.instance.increaseKillCount(); //Increase Ultimate Counter
        Destroy(gameObject);
    }
}
