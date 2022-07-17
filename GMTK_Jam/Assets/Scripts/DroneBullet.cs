using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public int damage;
    private GameObject player, drone;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        drone = GameObject.Find("Drone");
        direction = player.transform.position - drone.transform.position;
        rb.velocity = direction * bulletSpeed * 0.1f;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth character = hitInfo.GetComponent<PlayerHealth>();
        if (character != null)
        {
            character.TakeDamage(damage);
        }
        Debug.Log("Hit " + hitInfo.name);
        Destroy(gameObject);
    }

}
