using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed, damage;
    [SerializeField] private float hitWaitTime = 1f;
    [SerializeField] private float health = 1f; // Enemy Health
    [SerializeField] private int points; // Enemy Points
    [SerializeField] private GameObject[] powerupArr; //Powerup Array
    [SerializeField] private Material whitenMat; // Whiten sprite material
    private float dropChance = 5f; // 5% chance to drop a power-up

    private Rigidbody2D rb;
    private GameObject target;
    private float hitCounter;
    private SpriteRenderer spriteRenderer;
    private Material originalMat;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMat = spriteRenderer.material;
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

        if (collision.gameObject.tag == "Obstacle") 
        {
            GameObject obstacle = GameObject.FindGameObjectWithTag("Obstacle");   
            Physics2D.IgnoreCollision(obstacle.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
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
