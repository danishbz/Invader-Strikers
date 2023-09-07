using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
