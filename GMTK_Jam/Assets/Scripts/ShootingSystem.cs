using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    private int bulletCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletCount > 0)
        {
            Shoot();
        }

        if (Input.GetKeyDown("r") && bulletCount < 3)
        {
            Reload();
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletCount--;
    }

    void Reload()
    {
        bulletCount = 3;
        Debug.Log("Reload");
    }
}
