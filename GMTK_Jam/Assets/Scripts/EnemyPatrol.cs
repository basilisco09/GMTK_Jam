using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;     
    [SerializeField] Vector2[] patrolPoints;
    [SerializeField] private float patrolRange;

    private bool isFacingRight = true;
    private GameObject player;
    private int currentPoint = 0;       
    private Rigidbody2D ourRigidbody;
    private float distance;
    private Vector2 direction;

    void Awake()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        player = GameObject.Find("Player");
        if (Vector2.Distance(player.transform.position, transform.position) < patrolRange)
        {
            SetTarget();
        }

        if (Vector2.Distance(player.transform.position, transform.position) >= patrolRange)
        {
            Patrol();
        }

        Flip();
    }

    void SetTarget()
    {
        direction = (player.transform.position - transform.position);
        ourRigidbody.velocity = (direction * speed);
    }

    void Patrol()
    {
        distance = (patrolPoints[currentPoint] - (Vector2)transform.position).magnitude;

        if (distance <= stopDistance)
        {
            currentPoint = currentPoint + 1;
            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
        }

        direction = (patrolPoints[currentPoint] - (Vector2)transform.position).normalized;
        ourRigidbody.velocity = (direction * speed);
    }

    void Flip()
    {
        if(transform.position.x > player.transform.position.x && isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = false;
        }

        if(transform.position.x < player.transform.position.x && !isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = true;
        }
    }
}
