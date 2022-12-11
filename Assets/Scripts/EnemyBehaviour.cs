using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public string enemyName;

    private NavMeshAgent enemy;
    public Transform[] points;
    public int current;
    public Transform playerTarget;
    public bool isClose;
    public Rigidbody bulletPrefab;
    public GameObject enemyGunPoint;

    public Gun equippedGun;
    public bool canShoot = true;

    //HealthSystem
    public int maxHealth = 3;
    public float currentHealth;

    private void Awake()
    {
        equippedGun = Enemy.EnemyDictionary[enemyName].EnemyGun;
        maxHealth = Enemy.EnemyDictionary[enemyName].EnemyHealth;
    }

    private void Start()
    {
        current = 0;
        enemy = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        enemy.speed = Enemy.EnemyDictionary[enemyName].EnemySpeed;
    }

    private void Update()
    {
        //Check si le joueur est proche de player
        if (isClose)
        {
            enemy.stoppingDistance = Enemy.EnemyDictionary[enemyName].EnemyStoppingDistance;
            enemy.SetDestination(playerTarget.position);
            float distanceFromPlayer = Vector3.Distance(transform.position, playerTarget.position);
            //Debug.Log(distanceFromPlayer);
            transform.LookAt(playerTarget.position);
            if (distanceFromPlayer < Enemy.EnemyDictionary[enemyName].EnemyShootingDistance && canShoot)
            {
                transform.LookAt(playerTarget.position);
                canShoot = false;
                StartCoroutine(BulletDelay());
            }

        }
        else if (transform.position != points[current].position) //Si player est loin va patrol selon les transforms quon lui donne dans l'inspector
        {
            StopAllCoroutines();
            canShoot = true;
            enemy.stoppingDistance = 0;
            enemy.SetDestination(points[current].position);
            float distanceFromPatrol = Vector3.Distance(transform.position, points[current].position);
            if(distanceFromPatrol < 1)
            {
                current = (current + 1) % points.Length;
            }
        }
    }

    public IEnumerator BulletDelay()
    {
        //tire selon le FireRate du Gun
        for (int i = 0; i < equippedGun.FireRate; i++)
        {
            Rigidbody bullet;
            bullet = Instantiate(bulletPrefab, enemyGunPoint.transform.position, transform.rotation) as Rigidbody;
            bullet.velocity = enemyGunPoint.transform.forward * equippedGun.BulletSpeed;
            yield return StartCoroutine(BulletTimer());
        }
    }

    //Timer qui attend pour que la prochain ne touche pas a celle qui vient detre tirer
    public IEnumerator BulletTimer()
    {
        WaitForSeconds wfs = new WaitForSeconds(equippedGun.ReloadTimer);
        yield return wfs;
        canShoot = true;
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
