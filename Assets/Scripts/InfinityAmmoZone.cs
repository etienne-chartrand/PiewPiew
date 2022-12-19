using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityAmmoZone : MonoBehaviour
{
    //Zone pour le infinity Ammo potion
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

    //Au start envoie la coroutine pour la destruction
    private void Start()
    {
        StartCoroutine(DestroyZone(potionManager.equippedPotion.PotionTimeEffect));
    }

    //Si in on set infinity ammo
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gunManager.infinityAmmoEffect = true;
        }
    }

    //Si out on cancel infiny ammo 
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gunManager.infinityAmmoEffect = false;
        }
    }

    //Lorsque la coroutine est appele on start le timer pour detruire la zone et reset le infinity ammo
    private IEnumerator DestroyZone(float time)
    {
        WaitForSeconds wfs = new WaitForSeconds(time);
        yield return wfs;
        Destroy(gameObject);
        gunManager.infinityAmmoEffect = false;
    }
}
