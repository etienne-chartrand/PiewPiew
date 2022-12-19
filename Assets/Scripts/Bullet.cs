using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Se detruit apres 3sec
    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    //Hit ajoute du degat selon le type
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyBehaviour enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
            enemy.TakeDamage(20);
        }
        
        if(collision.gameObject.tag == "Player")
        {
            CharacterMovement player = collision.gameObject.GetComponent<CharacterMovement>();
            player.TakeDamage(20);
        }
    }
}
