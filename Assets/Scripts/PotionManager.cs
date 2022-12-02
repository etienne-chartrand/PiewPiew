using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public enum PotionType{
        heal,
        speed,
        infinityAmmo
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
}
