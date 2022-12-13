using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUoObject : MonoBehaviour
{
    public Vector3 offset;
    public Transform putPlayerHere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PickUp>().isPickedUp)
        {
            transform.position = putPlayerHere.position + offset;
            
        }
        else
        {
            transform.position = transform.position;
        }
    }

     
}
