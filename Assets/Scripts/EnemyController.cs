using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed, damage;
    [SerializeField] private float hitWaitTime = 1f;
    
    

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
}
