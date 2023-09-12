using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunUltEffect : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount);
        }
    }
}
