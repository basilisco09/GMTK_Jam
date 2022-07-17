using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackDelay = 1f;
    private float lastAttack = 0;
    private GameObject player;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        distance = player.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (distance < attackRange)
            if (Time.time - lastAttack > attackDelay)
            {
                Shoot();
                lastAttack = Time.time;
            }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
