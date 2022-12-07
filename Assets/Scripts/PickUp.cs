using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //public float maxdistance;
    public bool isPickedUp;
    public bool inRange;

    public void Update()
    {
        //RaycastHit hit;
        //if(Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z),out hit, maxdistance))
        //{
        //    Debug.DrawRay(new Vector3(transform.position.x, 0.5f, transform.position.z), new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z) * hit.distance, Color.yellow);
        //    Debug.Log("Did Hit");
        //}

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inRange)
            {
                isPickedUp = true;
                Debug.Log(";lkn");
            }
        }

    }




}
