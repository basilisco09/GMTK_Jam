using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;     
    [SerializeField] Vector2[] patrolPoints; 

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
}
