using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleUlt : MonoBehaviour
{
    [SerializeField] private GameObject rifleUltBullet; //Rifle Ultimate Bullet
    [SerializeField] private float bulletSpeed, ultDuration, bulletTime; //Bullet speed and time alive, and ult duration
    [SerializeField] private Transform ShootPoint; //Instantiate position
    [SerializeField] private AudioClip shootSound; //SFX

    private bool pressedOnce; //Check pressed once
    private WeaponChange weaponChange; //Weapon Change variable
    private void Awake()
    {
        weaponChange = gameObject.transform.parent.GetComponent<WeaponChange>();
    }
    private void Update()
    {
        bool isUltActive = UltimateManager.instance.getUltStatus();
        //If x is pressed & ult is active & has not been pressed, activate ult
        if (Input.GetKeyDown("x") && isUltActive && !pressedOnce)
        {
            weaponChange.enabled = false; //Deactivate Weapon Swapping
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

            var ultBullet = Instantiate(rifleUltBullet, ShootPoint.position, ShootPoint.rotation); //Spawn bullet
            Rigidbody2D ultBulletRB = ultBullet.GetComponent<Rigidbody2D>();
            ultBulletRB.velocity = transform.rotation * Vector2.right * bulletSpeed; //Move bullet
            Destroy(ultBullet, bulletTime); //Destroy bullet
            yield return new WaitForSeconds(0.01f); //Wait 0.01 seconds per bullet spawn
        }
        //Reset kill count after ult duration ends
        yield return new WaitForSeconds(2);
        weaponChange.enabled = true; //Reactivate Weapon Swapping
        pressedOnce = false;
        UltimateManager.instance.resetKillCount();
    }
}
