using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent enemy;
    public NavMeshPath path;
    public Transform playerTarget;
    public bool isClose;

    //HealthSystem
    public int maxHealth = 3;
    public float currentHealth;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (isClose)
        {
            enemy.SetDestination(playerTarget.position);
        }

        enemy.SetPath(path);

    }

    //Permet d'enlever de la vie
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
