using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotionManager : MonoBehaviour
{
    //Permet de determiner si les potions peuvent etre prise ou non
    //Determine le type de potion que l'on collide avec

    public CharacterMovement player;
    public GameObject healZone;
    public GameObject infinityAmmoZone;
    public TMP_Text healCount;
    public TMP_Text speedCount;
    public TMP_Text infinityAmmoCount;
    
    public enum PotionType{
        Heal,
        Speed,
        InfinityAmmo
    };
    public PotionType type;

    public Potion equippedPotion;
    private int healPotion;
    private int speedPotion;
    private int infinityAmmoPotion;

    //Check si le joueur peut prendre la potion/si inventory is full
    public bool CanITakePotion(string potionName)
    {
        equippedPotion = Potion.PotionDictionary[potionName];

        if(equippedPotion.PotionName == "Heal")
        {
            //Si peut ajoute au counter
            if(equippedPotion.PotionStack > healPotion)
            {
                healPotion++;
                healCount.text = healPotion.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(equippedPotion.PotionName == "Speed")
        {
            //Si peut ajoute au counter
            if (equippedPotion.PotionStack > speedPotion)
            {
                speedPotion++;
                speedCount.text = speedPotion.ToString();
                return true;
            }
            else
            {
                return false;
            }

        }
        else if (equippedPotion.PotionName == "InfinityAmmo")
        {
            //Si peut ajoute au counter
            if (equippedPotion.PotionStack > infinityAmmoPotion)
            {
                infinityAmmoPotion++;
                infinityAmmoCount.text = infinityAmmoPotion.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Check si on peut consume la potion
    public void ConsumePotion(PotionType potion)
    {
        string potionName = potion.ToString();
        equippedPotion = Potion.PotionDictionary[potionName];

        //Descend le counter
        if (potion == PotionType.Heal && healPotion > 0)
        {
            healPotion--;
            healCount.text = healPotion.ToString();
            Instantiate(healZone, new Vector3(player.transform.position.x, 0, player.transform.position.z), Quaternion.identity);
        }
        else if(potion == PotionType.Speed && speedPotion > 0)
        {
            //Descend le counter
            speedPotion--;
            speedCount.text = speedPotion.ToString();
            player.SpeedPotionEffect(equippedPotion.PotionTimeEffect);
        }
        else if(potion == PotionType.InfinityAmmo && infinityAmmoPotion > 0)
        {
            //Descend le counter
            infinityAmmoPotion--;
            infinityAmmoCount.text = infinityAmmoPotion.ToString();
            Instantiate(infinityAmmoZone, new Vector3(player.transform.position.x, 0, player.transform.position.z), Quaternion.identity);
        }
        else
        {
            //Aucune potion dans l'inventaire alors on envoie un feedback au joueur
            Debug.Log("No potion in inventory");
        }
    }
}
