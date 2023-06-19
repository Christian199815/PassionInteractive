using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer SR;
    public float movementSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FlipSprite();
    }

    void FlipSprite()
    {
        if(rb.velocity.x <= 1)
        {
            SR.flipX = true;
        }
        else if(rb.velocity.x >= 1)
        {
            SR.flipX = false;
        }
    }


    void Move()
    {
        float horInput = Input.GetAxisRaw("Horizontal");
        float verInput = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horInput * movementSpeed, verInput * movementSpeed);
        
    }
}
