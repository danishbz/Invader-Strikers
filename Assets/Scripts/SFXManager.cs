using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioClip damaged, gunSwap, shieldPowerup, speedPowerup, itemDrop, gameOver;
    private AudioSource audioSrc;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSrc = GetComponent<AudioSource>();
    }

    public void playDamaged() //Player damaged
    {
        audioSrc.PlayOneShot(damaged);
    }
    public void playShootSound(AudioClip shootsfx) //Shooting Bullets
    {
        audioSrc.clip = shootsfx;
        audioSrc.Play();
    }
    public void playGunSwap() //Gun Swapping
    {
        audioSrc.PlayOneShot(gunSwap);
    }
    public void playShieldPU() //Picking up Shield Powerup
    {
        audioSrc.PlayOneShot(shieldPowerup);
    }
    public void playSpeedPU() //Picking up Speed Powerup
    {
        audioSrc.PlayOneShot(speedPowerup);
    }
    public void playItemDrop() //Picking up Speed Powerup
    {
        audioSrc.PlayOneShot(itemDrop);
    }
    public void playGameOver()
    {
        audioSrc.PlayOneShot(gameOver);
    }
}
