using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionType : MonoBehaviour
{
    //Script sur les potions
    //Permet de récupérer les potions

    public string potionName;
    private PotionManager manager;
    private GameObject gameObjectManager;

    private void Awake()
    {
        gameObjectManager = GameObject.Find("PotionManager");
        manager = gameObjectManager.GetComponent<PotionManager>();
    }

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
