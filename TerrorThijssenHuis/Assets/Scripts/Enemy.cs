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
            sr = GetComponent<SpriteRenderer>();
            startingPosition = transform.position;
            SetRandomTargetPosition();
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