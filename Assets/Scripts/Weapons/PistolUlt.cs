using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolUlt : MonoBehaviour
{
    [SerializeField] private GameObject pistolUltBullet; //Pistol Ultimate Bullet
    [SerializeField] private float bulletSpeed, ultDuration; //Bullet speed and ult duration
    [SerializeField] private Transform ShootPoint; //Instantiate position
    [SerializeField] private AudioClip shootSound; //SFX

    private Rigidbody2D ultBulletRB; //Bullet rigidbody
    private bool pressedOnce; //Check pressed once
    private void Update()
    {
        bool isUltActive = UltimateManager.instance.getUltStatus();
        //If x is pressed & ult is active & has not been pressed, activate ult
        if (Input.GetKeyDown("x") && isUltActive && !pressedOnce)
        {
            pressedOnce = true;
            activateUlt();
        }
    }
    private void activateUlt()
    {
        SFXManager.instance.playShootSound(shootSound);
        var ultBullet = Instantiate(pistolUltBullet, ShootPoint.position, ShootPoint.rotation); //Spawn bullet
        ultBulletRB = ultBullet.GetComponent<Rigidbody2D>();
        ultBulletRB.velocity = transform.rotation * Vector2.right * bulletSpeed; //Move bullet
        Destroy(ultBullet, ultDuration); //Destroy Bullet
        StartCoroutine(resetCoroutine());
    }
    //Reset kill count after ult duration ends
    private IEnumerator resetCoroutine()
    {
        yield return new WaitForSeconds(ultDuration);
        pressedOnce = false;
        UltimateManager.instance.resetKillCount();
    }
}
