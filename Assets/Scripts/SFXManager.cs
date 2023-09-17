using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioClip damaged, 
                                       gunSwap, 
                                       shieldPowerup, 
                                       speedPowerup,
                                       destroyPowerup,
                                       healPowerup,
                                       itemDrop, 
                                       gameOver,
                                       shotgunUlt,
                                       alienShoot; //Audio Clips
    private AudioSource audioSrc; //Audio Source

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
    public void playShotgunUlt(bool isUltActive) //Shooting Bullets
    {
        audioSrc.clip = shotgunUlt;
        //If ult is active, loop sound
        if(isUltActive)
        {
            audioSrc.loop = true;
            audioSrc.Play();
        }
        else //Else stop looping
        {
            audioSrc.loop = false;
        }
        
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
    public void playDestroyPU() //Picking up Speed Powerup
    {
        audioSrc.PlayOneShot(destroyPowerup);
    }
    public void playHealPU() //Picking up Speed Powerup
    {
        audioSrc.PlayOneShot(healPowerup);
    }
    public void playItemDrop() //Picking up Speed Powerup
    {
        audioSrc.PlayOneShot(itemDrop);
    }
    public void playGameOver() //Game Over Sfx
    {
        audioSrc.PlayOneShot(gameOver);
    }
    public void playAlienShoot() //Game Over Sfx
    {
        audioSrc.PlayOneShot(alienShoot);
    }
}
