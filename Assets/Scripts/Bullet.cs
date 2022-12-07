using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Se detruit apres 5sec
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    //Hit un enemy ajoute du degat
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyBehaviour enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
            enemy.TakeDamage(20);
        }
    }
}
