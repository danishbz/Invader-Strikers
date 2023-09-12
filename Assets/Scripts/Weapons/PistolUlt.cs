using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolUlt : MonoBehaviour
{
    [SerializeField] private GameObject pistolUltBullet;
    [SerializeField] private float bulletSpeed, ultDuration;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private AudioClip shootSound;

    private Rigidbody2D ultBulletRB;
    private bool pressedOnce;
    private void Update()
    {
        bool isUltActive = UltimateManager.instance.getUltStatus();
        if (Input.GetKeyDown("x") && isUltActive && !pressedOnce)
        {
            pressedOnce = true;
            activateUlt();
        }
    }
    private void activateUlt()
    {
        SFXManager.instance.playShootSound(shootSound);
        var ultBullet = Instantiate(pistolUltBullet, ShootPoint.position, ShootPoint.rotation);
        ultBulletRB = ultBullet.GetComponent<Rigidbody2D>();
        ultBulletRB.velocity = transform.rotation * Vector2.right * bulletSpeed;
        StartCoroutine(resetCoroutine());
    }
    private IEnumerator resetCoroutine()
    {
        yield return new WaitForSeconds(ultDuration);
        pressedOnce = false;
        UltimateManager.instance.resetKillCount();
    }
}
