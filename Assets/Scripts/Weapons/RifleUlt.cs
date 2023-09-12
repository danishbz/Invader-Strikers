using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleUlt : MonoBehaviour
{
    [SerializeField] private GameObject rifleUltBullet;
    [SerializeField] private float bulletSpeed, ultDuration, bulletTime;
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
            StartCoroutine(activateUlt());
        }
    }
    private IEnumerator activateUlt()
    {
        float startTime = Time.time;
        while (Time.time - startTime < ultDuration)
        {
            SFXManager.instance.playShootSound(shootSound);

            var ultBullet = Instantiate(rifleUltBullet, ShootPoint.position, ShootPoint.rotation);
            Rigidbody2D ultBulletRB = ultBullet.GetComponent<Rigidbody2D>();
            ultBulletRB.velocity = transform.rotation * Vector2.right * bulletSpeed;
            Destroy(ultBullet, bulletTime);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2);
        pressedOnce = false;
        UltimateManager.instance.resetKillCount();
    }
}
