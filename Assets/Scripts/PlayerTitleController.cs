using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTitleController : MonoBehaviour
{
    [SerializeField] private Transform[] pointsArr; //Array of points to move to
    [SerializeField] private float moveSpeed;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Transform randomPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        randomPoint = pointsArr[randomizePoint()]; //Randomize target point
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (randomPoint.position - transform.position).normalized * moveSpeed;
        var dist = Vector2.Distance(randomPoint.position, transform.position);
        if (dist < 0.2f)
        {
            randomPoint = pointsArr[randomizePoint()];
        }

        // Flip sprite when player posX is BIGGER than enemy posX
        if (transform.position.x < randomPoint.position.x)
        {
            spriteRenderer.flipX = false;
        }
        // Flip sprite when player posX is SMALLER than enemy posX
        else
        {
            spriteRenderer.flipX = true;
        }
    }
    private int randomizePoint()
    {
        int randomize = Random.Range(0, pointsArr.Length);
        return randomize;
    }
}
