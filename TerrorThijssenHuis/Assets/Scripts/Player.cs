using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float movementSpeed = 2;

    private List<string> inventory = new List<string>();
    private bool nearDoor = false;

    public Text interactionText;
    private int interactionTextOffsetX = 125;
    private int interactionTextOffsetY = 50;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        FlipSprite();
    
        if (nearDoor)
        {
            interactionText.text = "Press 'E' to open door";
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i] == "Key")
                    {
                        // Open door (replace later with more suitable behavior)
                        Destroy(GameObject.FindWithTag("Door"));
                    }
                }
            }
        }

        else 
        {
            interactionText.text = "";
        }
    }

    void FlipSprite()
    {
        if(rb.velocity.x <= 1)
        {
            sr.flipX = true;
        }
        else if(rb.velocity.x >= 1)
        {
            sr.flipX = false;
        }
    }
     
    public void LateUpdate()
    {
        interactionText.transform.position = new Vector2(Camera.main.WorldToScreenPoint(transform.position).x + interactionTextOffsetX, 
                                                        Camera.main.WorldToScreenPoint(transform.position).y + interactionTextOffsetY);
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

        if (other.tag == "Door")
        {
            nearDoor = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            nearDoor = false;
        }
    }
}
