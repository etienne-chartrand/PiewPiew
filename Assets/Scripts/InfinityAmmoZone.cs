using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityAmmoZone : MonoBehaviour
{
    private GameObject player;
    private CharacterMovement playerCM;
    private PotionManager potionManager;
    private GameObject PotionManager;
    private GunManager gunManager;


    private void Awake()
    {
        player = GameObject.Find("Player");
        playerCM = player.GetComponent<CharacterMovement>();
        PotionManager = GameObject.Find("PotionManager");
        potionManager = PotionManager.GetComponent<PotionManager>();
        gunManager = player.GetComponentInChildren<GunManager>();
    }

    private void Start()
    {
        Destroy(gameObject, potionManager.equippedPotion.PotionTimeEffect);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gunManager.infinityAmmoEffect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gunManager.infinityAmmoEffect = false;
        }
    }
}
