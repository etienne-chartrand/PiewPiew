using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //HealthSystem
    public int maxHealth = 3;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    //Permet d'enlever de la vie
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
