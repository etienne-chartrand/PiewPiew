using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    // check si le joueur est dans la trigger zone autour de l'objet qu'on peut pick-up
    private GameObject player;
    private PickUp pickUp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pickUp = player.GetComponent<PickUp>();
    }

    //Check si player est entré
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
           pickUp.inRange = true; 
        }
    }

    //Check si player est sortie
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pickUp.inRange = false;
        }
    }
}
