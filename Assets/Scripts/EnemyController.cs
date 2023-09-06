using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed, damage;
    [SerializeField] private float hitWaitTime = 1f;
    [SerializeField] private float health = 1f; // Enemy Health
    [SerializeField] private int points; // Enemy Points
    public GameObject shieldEffectPreFab; // Reference to the shield power-up prefab
    public GameObject speedPowerUpPrefab; // Reference to the speed power-up prefab
    private float dropChance = 5f; // 5% chance to drop a power-up

    private Rigidbody2D rb;
    private GameObject target;
    private float hitCounter;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            rb.velocity = (target.transform.position - transform.position).normalized * moveSpeed;

            // Flip sprite when player posX is BIGGER than enemy posX
            if (transform.position.x < target.transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            // Flip sprite when player posX is SMALLER than enemy posX
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            HealthManager.instance.ApplyDamage(damage);

            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            ScoreManager.instance.UpdateScore(points);
            // Generate a random number between 0 and 100
            float randomValue = Random.Range(0f, 100f);

            // Check if the random number is less than or equal to the drop chance
            if (randomValue <= dropChance)
            {
                // Generate another random value to determine which power-up to drop
                float powerUpRandomValue = Random.Range(0f, 1f);

                if (powerUpRandomValue < 0.5f)
                {
                    // Instantiate the Shield PowerUp at the enemy's position
                    Instantiate(shieldEffectPreFab, transform.position, Quaternion.identity);
                }
                else
                {
                    // Instantiate the Speed PowerUp at the enemy's position
                    Instantiate(speedPowerUpPrefab, transform.position, Quaternion.identity);
                }
            }

            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}
