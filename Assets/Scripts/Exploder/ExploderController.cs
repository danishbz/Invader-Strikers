using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ExploderController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float explosionDamage;
    [SerializeField] private float deathTimer = 1.25f;
    //[SerializeField] private float explosionRadius = 3f;

    private bool isImmobilized = false;
    private Rigidbody2D rb;
    private GameObject target;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (target && !isImmobilized)
        {
            animator.SetBool("isWalking", true);
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
        if (isImmobilized)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") 
        {
            GameObject obstacle = GameObject.FindGameObjectWithTag("Obstacle");   
            Physics2D.IgnoreCollision(obstacle.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    public void ExplodeAnim()
    {
        isImmobilized = true;
        animator.SetBool("isWalking", false);
        Debug.Log("ExplodeAnim Called");
        animator.SetTrigger("Explosion");
        StartCoroutine(DestroySelfCoroutine());
    }
    public void Explode()
    {
        Debug.Log("Explode Called");
        HealthManager.instance.ApplyDamage(explosionDamage);
    }
    private IEnumerator DestroySelfCoroutine()
    {
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }
}

