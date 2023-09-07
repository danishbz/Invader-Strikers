using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float moveSpeed;

    public Animator anim;

    private float speedIncreasePercentage = 0.1f; // 1% increase in speed
    private float maxSpeed = 8f; // Maximum speed

    // Start is called before the first frame update
    void Start()
    {

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

        // Calculate the new speed based on the percentage increase
        float newSpeed = moveSpeed + moveSpeed * speedIncreasePercentage;

        // Cap the speed to the maximum value
        if (newSpeed > maxSpeed)
        {
            newSpeed = maxSpeed;
        }
    }

    public void IncreaseSpeed()
    {
        float newSpeed = moveSpeed + moveSpeed * speedIncreasePercentage;

        // Cap the speed to the maximum value
        if (newSpeed > maxSpeed)
        {
            newSpeed = maxSpeed;
        }

        // Update the player's move speed
        moveSpeed = newSpeed;
    }
}
