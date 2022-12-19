using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Permet de pickUp
    public bool isPickedUp;
    public bool inRange;
    private float holdDownStartTime;
    public bool isPressing;
    public float timeBeforeRelease;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //PickUp si proche
            if(inRange)
            {
                if (!isPickedUp)
                {
                    isPickedUp = true;
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
            }
        }
    }
}
