using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float movementSpeed = 2f;

    public float knockbackForce = 100f;
    public float slideDuration = 0.2f;

    public int damageAmount;

    private Transform target;
    private SpriteRenderer sr;
    private Rigidbody2D playerRigidbody;
    private Coroutine slideCoroutine;

    public float maxDistanceFromStart = 3f;

    private Vector2 startingPosition;
    private Vector2 targetPosition;

    public Player player;
    public Transform waypoint;
    private bool reachedWaypoint = false;
    public float roomBounds;
    private bool inNativeRoom = true;

    private bool isIdleMoving;
    private float movementDuration = 5f;
    private float movementTimer;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
        SetRandomTargetPosition();
    }

    private void Update()
    {
        if (transform.position.x < player.transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (Mathf.Abs(transform.position.x) < Mathf.Abs(roomBounds))
        {
            inNativeRoom = false;
        }

        else
        {
            inNativeRoom = true;
            reachedWaypoint = false;
        }

        if (target != null)
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }

        else
        {
            if (!inNativeRoom && reachedWaypoint == false)
            {
                targetPosition = new Vector2(waypoint.position.x, waypoint.position.y);
                if (new Vector2(transform.position.x, transform.position.y) == targetPosition)
                {
                    reachedWaypoint = true;
                }
            }
            else if (!inNativeRoom && reachedWaypoint == true)
            {
                targetPosition = startingPosition;
            }
            else
            {
                if (isIdleMoving && movementTimer >= movementDuration)
                {
                    isIdleMoving = false;
                    SetRandomTargetPosition();
                }

                if (!isIdleMoving)
                {
                    isIdleMoving = true;
                    movementTimer = 0f;
                    SetRandomTargetPosition();
                }
            }

            MoveTowardsTargetPosition();

            movementTimer += Time.deltaTime;
        }
    }

    private bool ReachedTargetPosition()
    {
        return Vector2.Distance(transform.position, targetPosition) < 0.1f;
    }

    private void SetRandomTargetPosition()
    {
        float randomX = Random.Range(startingPosition.x - maxDistanceFromStart, startingPosition.x + maxDistanceFromStart);
        float randomY = Random.Range(startingPosition.y - maxDistanceFromStart, startingPosition.y + maxDistanceFromStart);
        targetPosition = new Vector2(randomX, randomY);
    }

    private void MoveTowardsTargetPosition()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
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
                playerController.LoseLife(damageAmount);
                
                Vector2 knockbackDirection = (other.transform.position - transform.position);
                playerRigidbody.velocity = Vector2.zero;
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