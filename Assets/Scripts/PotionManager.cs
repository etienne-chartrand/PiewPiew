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


    private void Awake()
    {
        if(type == PotionType.heal)
        {
            equippedPotion = Potion.PotionDictionary["Heal"];
        }
        else if(type == PotionType.speed)
        {
            equippedPotion = Potion.PotionDictionary["Speed"];
        }
        else if(type == PotionType.infinityAmmo)
        {
            equippedPotion = Potion.PotionDictionary["InfinityAmmo"];
        }
    }

    public bool CanITakePotion(string potionName)
    {
        if (Potion.PotionDictionary[potionName].PotionStack == healPotion)
        {
            return false;
        }
        else
        {
            healPotion++;
            return true;
        }
        
    }
}
