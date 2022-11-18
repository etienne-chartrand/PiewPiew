using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Player qu'on veut suivre
    public Transform followPlayer;

    private Transform cameraTransform;

    //Offset qu'on veut add a la cam par rapport au player
    public Vector3 playerOffset;

    //Vitesse de la cam pour suivre le joueur
    public float MoveSpeed;

    
    void Start()
    {
        //Set nos variables
        MoveSpeed = 400f;
        cameraTransform = transform;
    }

    public void SetTarget(Transform newTransformTarget)
    {
        followPlayer = newTransformTarget;
    }

    private void LateUpdate()
    {
        if(followPlayer != null)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position,followPlayer.position + playerOffset, MoveSpeed * Time.deltaTime);
        }
    }

}
