using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    //Check si le player est proche poru changer le behaviour enemy
    private EnemyBehaviour enemyBehaviour;

    private void Start()
    {
        enemyBehaviour = GetComponentInParent<EnemyBehaviour>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enemyBehaviour.isClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemyBehaviour.isClose = false;
        }
    }
}
