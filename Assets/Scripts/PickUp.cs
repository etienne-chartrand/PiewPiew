using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //public float maxdistance;
    public bool isPickedUp;
    public bool inRange;
    private float holdDownStartTime;
    public bool isPressing;
    public float timeBeforeRelease;

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
                //if (isPickedUp)
                //{
                //    if (Input.GetKeyDown(KeyCode.E))
                //    {
                //        isPickedUp = false;
                //        Debug.Log("Dropped");
                //    }
                //}

                if (isPickedUp==false)
                {
                    isPickedUp = true;
                    Debug.Log("Picked-Up");
                }
                if (isPickedUp)
                {
                    holdDownStartTime = Time.time;
                    isPressing = true;

                }

            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isPressing = false;
        }
        if(isPressing)
        { 
            if (Time.time - holdDownStartTime >= timeBeforeRelease)
            {
                isPickedUp = false;
                Debug.Log("Dropped");
            }
        }
        //if (isPickedUp)
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        isPickedUp = false;
        //        Debug.Log("Dropped");
        //    }
        //}




    }
    //public void LateUpdate()
    //{
    //    if (isPickedUp)
    //    {
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            isPickedUp = false;
    //            Debug.Log("Dropped");
    //        }
    //    }
    //}




}
