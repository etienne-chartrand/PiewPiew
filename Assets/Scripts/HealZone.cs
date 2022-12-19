using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    //Zone de heal lorsque player prends potion heal
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

    //Detruit l'objet apres la creation selon la duree
    private void Start()
    {
        Destroy(gameObject, potionManager.equippedPotion.PotionTimeEffect);
    }

    //Si joueur est in on heal
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerCM.HealPlayer(5, potionManager.equippedPotion.PotionTimeEffect);
        }
    }

    //Si out on arrete le heal
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {     
            playerCM.StopHealing();
        }
    }
}
