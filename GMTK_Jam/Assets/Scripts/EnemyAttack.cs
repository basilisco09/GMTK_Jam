using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] public int damage;
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
        if(distance < attackRange)
            if(Time.time - lastAttack > attackDelay)
            {
                Attack();
                lastAttack = Time.time;
            }
    }

    private void Attack()
    {
        //animator.SetTrigger("MeleeAttack");
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (player != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Debug.Log("They hit " + player.name);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
