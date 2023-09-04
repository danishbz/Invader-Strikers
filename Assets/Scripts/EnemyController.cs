using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float hitWaitTime = 1f;
    [SerializeField] private float health = 1f; // enemy health

    private Rigidbody2D rb;
    private Transform target;
    private float hitCounter;
    private SpriteRenderer spriteRenderer;
    public GameObject powerUpPrefab;
    public GameObject speedPowerUpPrefab;
    private float dropChance = 0.02f; // 2% chance to drop any power-up

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            rb.velocity = (target.position - transform.position).normalized * moveSpeed;
        }
        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
        //Flip sprite when player posX is BIGGER than enemy posX
        if (transform.position.x < target.position.x)
        {
            spriteRenderer.flipX = true;
        }
        //Flip sprite when player posX is SMALLER than enemy posX
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealthController.instance.ApplyDamage(damage);

            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            // Generate a random number between 0 and 1 (0% to 100%)
            float randomValue = Random.Range(0f, 1f);

            // Check if the random number is less than or equal to the drop chance
            if (randomValue <= dropChance)
            {
                // Generate another random number to decide which power-up to drop
                float powerUpRandomValue = Random.Range(0f, 1f);

                if (powerUpRandomValue <= 0.5f)
                {
                    // Instantiate the power-up at the enemy's position
                    Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    // Instantiate the speed power-up at the enemy's position
                    Instantiate(speedPowerUpPrefab, transform.position, Quaternion.identity);
                }
            }

=======
            ScoreManager.instance.UpdateScore(points);
>>>>>>> 34ca63dac42326b8c8198d8e4988a810bb59aefc
=======
>>>>>>> parent of 47c7d32 (GameOver screen, Timer, score, highscore)
            Destroy(gameObject);
        }
    }
}
