using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionType : MonoBehaviour
{
    
    public string potionName;
    public PotionManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (manager.CanITakePotion(potionName))
            {
                Destroy(gameObject);
            };
        }
    }
}
