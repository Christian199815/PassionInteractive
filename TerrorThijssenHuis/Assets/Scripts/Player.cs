using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    public float movementSpeed = 2.5f;

    private int lives = 5;
    private List<string> inventory = new List<string>();
    private bool nearDoor = false;
    private bool inSafeRoom = false;
    [HideInInspector] public bool notHit = true;

    public Text interactionText;

    public Material[] spriteMaterials;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (notHit)
        {
            Move();
            FlipSprite();
            CheckDoor();
        }
    }

    void Move()
    {
        float horInput = Input.GetAxisRaw("Horizontal");
        float verInput = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horInput * movementSpeed, verInput * movementSpeed);

        if (rb.velocity != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
        }

        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void FlipSprite()
    {
        if (rb.velocity.x > 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x < 0)
        {
            sr.flipX = false;
        }
    }

    void CheckDoor()
    {
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

        if (other.tag == "SafeRoom")
        {
            inSafeRoom = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            nearDoor = false;
        }

        if (other.tag == "SafeRoom")
        {
            inSafeRoom = false;
        }
    }

    public void LoseLife()
    {
        lives--;
        gameManager.LivesUI(lives);
        if (lives <= 0)
        {
            gameManager.Death();
        }
    }
}
