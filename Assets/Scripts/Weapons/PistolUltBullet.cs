using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolUltBullet : MonoBehaviour
{
    [SerializeField] private float damageAmount; //Amount of damage

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If enemy, apply damage
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyDamager>().TakeDamage(damageAmount);
        }
    }
}