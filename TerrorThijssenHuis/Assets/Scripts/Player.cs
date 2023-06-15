using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementSpeed = 2;

    List<string> inventory = new List<string>();

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horInput = Input.GetAxisRaw("Horizontal");
        float verInput = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horInput * movementSpeed, verInput * movementSpeed);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Key")
        {
            Destroy(other.gameObject);
            inventory.Add("Key");
            // Add string Key to inventory list
        }
    }
}
