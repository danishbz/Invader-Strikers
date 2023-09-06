using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float moveSpeed;

    public Animator anim;

    private Transform shieldEffectTransform; // Reference to the shield effect transform
    private bool hasImmunity = false;
    private float immunityDuration = 5f; // Change this to your desired duration in seconds
    private float immunityTimer = 0f;

    private float speedIncreasePercentage = 0.1f; // 1% increase in speed
    private float maxSpeed = 8f; // Maximum speed

    // Start is called before the first frame update
    void Start()
    {
        // Find the shieldEffect GameObject using Transform.Find
        shieldEffectTransform = transform.Find("shieldEffect");

        // Deactivate it by default
        if (shieldEffectTransform != null)
        {
            shieldEffectTransform.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //Debug.Log(moveInput);

        moveInput.Normalize();

        //Debug.Log(moveInput);

        transform.position += moveInput * moveSpeed * Time.deltaTime;

        if(moveInput != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else{
            anim.SetBool("isMoving", false);
        }

        // Check if the player has immunity
        if (hasImmunity)
        {
            immunityTimer -= Time.deltaTime;
            if (immunityTimer <= 0f)
            {
                // Immunity duration has expired, deactivate the shield effect
                DeactivateShieldEffect();
                hasImmunity = false;
            }
        }
        // Calculate the new speed based on the percentage increase
        float newSpeed = moveSpeed + moveSpeed * speedIncreasePercentage;

        // Cap the speed to the maximum value
        if (newSpeed > maxSpeed)
        {
            newSpeed = maxSpeed;
        }
    }

    // Method to activate the shield effect and start immunity
    public void ActivateShieldEffect()
    {
        // Check if the shieldEffectTransform is found
        if (shieldEffectTransform != null)
        {
            shieldEffectTransform.gameObject.SetActive(true);
            hasImmunity = true;
            immunityTimer = immunityDuration;
        }
    }

    // Method to deactivate the shield effect
    public void DeactivateShieldEffect()
    {
        // Check if the shieldEffectTransform is found
        if (shieldEffectTransform != null)
        {
            shieldEffectTransform.gameObject.SetActive(false);
        }
    }
    // Handle collision with SpeedPowerUp
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedPowerUp"))
        {
            // Get the SpeedPowerUp script from the collided object
            SpeedPowerUp speedPowerUp = collision.GetComponent<SpeedPowerUp>();
            if (speedPowerUp != null)
            {
                // Apply the speed increase from the SpeedPowerUp
                float newSpeed = moveSpeed + moveSpeed * speedPowerUp.speedIncreasePercentage;

                // Cap the speed to the maximum value
                if (newSpeed > speedPowerUp.maxSpeed)
                {
                    newSpeed = speedPowerUp.maxSpeed;
                }

                // Update the player's move speed
                moveSpeed = newSpeed;

                // Destroy the SpeedPowerUp GameObject
                Destroy(collision.gameObject);
            }
        }
    }

}
