using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{   
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float stoppingDistance = 3f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float bulletSpeed = 2f;
    private Rigidbody2D rb;
    private GameObject target;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float weaponCooldown;
    public float startTimeBtwShots;
    public GameObject projectile;
    public Transform shootingPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        weaponCooldown = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Move();
            Shoot();
        }
    }

    private void Move(){
        if(Vector2.Distance(transform.position, target.transform.position) > stoppingDistance)
        {
            rb.velocity = (target.transform.position - transform.position).normalized * moveSpeed;

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
        else if(Vector2.Distance(transform.position, target.transform.position) < stoppingDistance)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Shoot(){
        if(Vector2.Distance(transform.position, target.transform.position) < attackRange){
            animator.SetBool("inRange", true);
            if(weaponCooldown <= 0){
                SFXManager.instance.playAlienShoot();
                GameObject b = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
                Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
                brb.velocity = (target.transform.position - b.transform.position).normalized * bulletSpeed;
                weaponCooldown = startTimeBtwShots;
            }
            else{
                weaponCooldown -= Time.deltaTime;
            }
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
}
