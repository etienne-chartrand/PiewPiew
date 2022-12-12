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
    private int healPotionCount;
    private int speedPotionCount;
    private int infinityAmmoPotionCount;

    //Check si le joueur peut prendre la potion/si inventory is full
    public bool CanITakePotion(string potionName)
    {
        equippedPotion = Potion.PotionDictionary[potionName];

        if(equippedPotion.PotionName == "Heal")
        {
            //Si peut ajoute au counter
            if(equippedPotion.PotionStack > healPotionCount)
            {
                healPotionCount++;
                healCount.text = healPotionCount.ToString();
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
            if (equippedPotion.PotionStack > speedPotionCount)
            {
                speedPotionCount++;
                speedCount.text = speedPotionCount.ToString();
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
            if (equippedPotion.PotionStack > infinityAmmoPotionCount)
            {
                infinityAmmoPotionCount++;
                infinityAmmoCount.text = infinityAmmoPotionCount.ToString();
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
        if (potion == PotionType.Heal && healPotionCount > 0)
        {
            healPotionCount--;
            healCount.text = healPotionCount.ToString();
            Instantiate(healZone, new Vector3(player.transform.position.x, 0, player.transform.position.z), Quaternion.identity);
        }
        else if(potion == PotionType.Speed && speedPotionCount > 0)
        {
            //Descend le counter
            speedPotionCount--;
            speedCount.text = speedPotionCount.ToString();
            player.SpeedPotionEffect(equippedPotion.PotionTimeEffect);
        }
        else if(potion == PotionType.InfinityAmmo && infinityAmmoPotionCount > 0)
        {
            //Descend le counter
            infinityAmmoPotionCount--;
            infinityAmmoCount.text = infinityAmmoPotionCount.ToString();
            Instantiate(infinityAmmoZone, new Vector3(player.transform.position.x, 0, player.transform.position.z), Quaternion.identity);
        }
        else
        {
            //Aucune potion dans l'inventaire alors on envoie un feedback au joueur
            
        }
    }
}
