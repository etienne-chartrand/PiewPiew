using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUoObject : MonoBehaviour
{
    public Vector3 offset;
    public Transform putPlayerHere;
    public Rigidbody Rigidbody;
    private PickUp pickUp;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pickUp = player.GetComponent<PickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (pickUp.isPickedUp)
            {

                transform.position = putPlayerHere.position + offset;
                Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            
            }
            else
            {
                transform.position = transform.position;
                Rigidbody.constraints = RigidbodyConstraints.None;
            }
        
    }
}
