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
        if(target)
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
        if(collision.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealthController.instance.ApplyDamage(damage);

            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
