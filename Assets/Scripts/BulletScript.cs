using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    // allow piercing bullets
    [SerializeField] private bool canPierce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount);
            if(!canPierce)
            {
                Destroy(gameObject);
            }
        }
        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject); 
        }
    }
}
