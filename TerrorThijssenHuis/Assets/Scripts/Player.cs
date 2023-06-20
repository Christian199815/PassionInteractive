using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    public float movementSpeed = 2.5f;

   [SerializeField] private DialogueUI DUI;

    [SerializeField] public int lives = 5;
    private List<string> inventory = new List<string>();
    private bool nearDoor = false;
    private bool liftDoor1 = false;
    private bool liftDoor2 = false;
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
            InSafeRoom();
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
                //if is southdoor do next
                DUI.playMessage(5, 2);

                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i] == "Key")
                    {
                        // Open door (replace later with more suitable behavior)
                        Destroy(GameObject.FindWithTag("Door"));
                        DUI.playMessage(6, 2);

                    }
                    else
                    {
                       
                    }
                }

                //if is lift door do next

                
            }
        }
        else if (liftDoor1)
        {
            interactionText.text = "Press 'E' to open door";
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameManager.StartExploring();
                DUI.playMessage(2, DUI.messageDisplaySeconds);
            }
        }
        else if(liftDoor2)
        {
            interactionText.text = "Press 'E' to open door";
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameManager.EndExploring();
                DUI.playMessage(11, DUI.messageDisplaySeconds);
            }
        }
        else 
        {
            interactionText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Key":
                Destroy(other.gameObject);
                inventory.Add("Key");
                DUI.playMessage(8, 3);
                break;
            case "Door":
                nearDoor = true;
                break;
            case "LiftDoor1":
                liftDoor1 = true;
                break;
            case "LiftDoor2":
                liftDoor2 = true;
                break;
            case "SafeRoom":
                inSafeRoom = true;
                break;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Door":
                nearDoor = false;
                break;
            case "LiftDoor1":
                liftDoor1 = false;
                break;
            case "LiftDoor2":
                liftDoor2 = false;
                break;
            case "SafeRoom":
                inSafeRoom = false;
                break;
        }
    }

    public void LoseLife()
    {
        lives--;
        DUI.playMessage(7, 2); 
        if (lives <= 0)
        {
            gameManager.Death();
        }
    }


    public void InSafeRoom()
    {
        if(inSafeRoom && lives >= 1)
        {
            StartCoroutine(MentalHealthTimer(5));
        }
    }


    IEnumerator MentalHealthTimer(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        lives = 5;
    }

}
