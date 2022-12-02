using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    private GameObject player;
    private CharacterMovement playerCM;
    private PotionManager potionManager;
    private GameObject PotionManager;


    private void Awake()
    {
        player = GameObject.Find("Player");
        playerCM = player.GetComponent<CharacterMovement>();
        PotionManager = GameObject.Find("PotionManager");
        potionManager = PotionManager.GetComponent<PotionManager>();
    }

    private void Start()
    {
        Destroy(gameObject, potionManager.equippedPotion.PotionTimeEffect);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("in");
            playerCM.HealPlayer(5, potionManager.equippedPotion.PotionTimeEffect);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("out");
            playerCM.StopHealing();
        }
    }
}
