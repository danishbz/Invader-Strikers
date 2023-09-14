using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolUltBullet : MonoBehaviour
{
    [SerializeField] private float damageAmount, duration;

    private void Update()
    {
        Destroy(gameObject, duration);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyDamager>().TakeDamage(damageAmount);
        }
    }
}