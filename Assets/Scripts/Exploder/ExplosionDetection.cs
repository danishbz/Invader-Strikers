using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDetection : MonoBehaviour
{
    [SerializeField] private float explodeDuration;
    private ExploderController exploderCon;
    private void Start()
    {
        exploderCon = gameObject.transform.parent.GetComponent<ExploderController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            exploderCon.ExplodeAnim();
            exploderCon.Invoke("Explode", explodeDuration);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            exploderCon.CancelInvoke("Explode");
        }
    }
}
