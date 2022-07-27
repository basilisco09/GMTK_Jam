using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonParameters : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private MeleeAttack meleeAtack;
    private int randValue; 
    // Start is called before the first frame update
    void Start()
    {
        SetRandonParameters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Sorting()
    {
        randValue = Random.Range(1, 6);
        return randValue;
    }

    public void SetRandonParameters()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.health = Sorting();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.speed = Sorting() * 3;
        meleeAtack = player.GetComponent<MeleeAttack>();
        meleeAtack.damage = Sorting();
    }
}
