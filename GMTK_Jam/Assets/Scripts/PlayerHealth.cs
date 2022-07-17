using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Transform diceTransform;
    [SerializeField] private GameObject[] dices;
    [HideInInspector] public int health;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = health - 1;
        Instantiate(dices[index], diceTransform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        Destroy(dices[index]);
        index -= damage;
        if (index < 0) 
        {
            Die();
        }
        else
        {
            Instantiate(dices[index], diceTransform);
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("Game Over");
    }
}
