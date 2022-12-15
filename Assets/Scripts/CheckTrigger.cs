using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    
    private GameObject player;
    private PickUp pickUp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pickUp = player.GetComponent<PickUp>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
           pickUp.inRange = true;
           Debug.Log("entered");
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pickUp.inRange = false;
            Debug.Log("exited");
        }
    }
}
