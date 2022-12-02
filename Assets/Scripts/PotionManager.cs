using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    //Permet de determiner si les potions peuvent etre prise ou non
    //Determine le type de potion que l'on collide avec

    public CharacterMovement player;
    public GameObject healZone;
    
    public enum PotionType{
        Heal,
        Speed,
        InfinityAmmo
    };
    public PotionType type;

    public Potion equippedPotion;
    public int healPotion;
    public int speedPotion;
    public int infinityAmmoPotion;


    public bool CanITakePotion(string potionName)
    {
        equippedPotion = Potion.PotionDictionary[potionName];

        if(equippedPotion.PotionName == "Heal")
        {
            if(equippedPotion.PotionStack > healPotion)
            {
                healPotion++;
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(equippedPotion.PotionName == "Speed")
        {
            if (equippedPotion.PotionStack > speedPotion)
            {
                speedPotion++;
                return true;
            }
            else
            {
                return false;
            }

        }
        else if (equippedPotion.PotionName == "InfinityAmmo")
        {
            if (equippedPotion.PotionStack > infinityAmmoPotion)
            {
                infinityAmmoPotion++;
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

    public void ConsumePotion(PotionType potion)
    {
        string potionName = potion.ToString();
        equippedPotion = Potion.PotionDictionary[potionName];

        if (potion == PotionType.Heal && healPotion > 0)
        {
            healPotion--;
            Instantiate(healZone, new Vector3(player.transform.position.x, 0, player.transform.position.z), Quaternion.identity);
        }
        else if(potion == PotionType.Speed && speedPotion > 0)
        {
            speedPotion--;
            player.SpeedPotionEffect(equippedPotion.PotionTimeEffect);
        }
        else if(potion == PotionType.InfinityAmmo && infinityAmmoPotion > 0)
        {

        }
        else
        {
            Debug.Log("No potion in inventory");
        }
    }
}
