using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float knockbackForce = 100f;
    public float slideDuration = 0.2f;
    private Transform target;
    private SpriteRenderer sr;
    private Rigidbody2D playerRigidbody;
    private Coroutine slideCoroutine;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (target != null)
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        
            if (transform.position.x < target.position.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            Player playerController = other.gameObject.GetComponent<Player>();
            if (playerController != null)
            {
                playerController.LoseLife();
                
                Vector2 knockbackDirection = (other.transform.position - transform.position);
                playerRigidbody.velocity = Vector2.zero; // Reset player's velocity
                playerRigidbody.AddForce(knockbackDirection * knockbackForce);

                if (slideCoroutine != null)
                {
                    StopCoroutine(slideCoroutine);
                }
                slideCoroutine = StartCoroutine(SlideCoroutine(playerController));
            }
        }
    }

    private IEnumerator SlideCoroutine(Player player)
    {
        player.notHit = false;
        player.gameObject.GetComponent<SpriteRenderer>().material = player.spriteMaterials[1];
        yield return new WaitForSeconds(slideDuration);
        player.notHit = true;
        player.gameObject.GetComponent<SpriteRenderer>().material = player.spriteMaterials[0];
        slideCoroutine = null;
    }
}
