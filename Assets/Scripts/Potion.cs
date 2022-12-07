using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion
{
    public string PotionName { get; set; }

    public float PotionTimeEffect { get; set; }

    public bool PotionIsAreaOfEffect { get; set; }

    public int PotionStack { get; set; }

    public Potion()
    {
        this.PotionName = "";
        this.PotionTimeEffect = 0f;
        this.PotionIsAreaOfEffect = false;
        this.PotionStack = 0;
    }

    public Potion(string potionName, float potionTimeEffect, bool potionIsAreaOfEffect, int potionStack)
    {
        PotionName = potionName;
        PotionTimeEffect = potionTimeEffect;
        PotionIsAreaOfEffect = potionIsAreaOfEffect;
        PotionStack = potionStack;
    }

    public static Dictionary<string, Potion> PotionDictionary = new Dictionary<string, Potion>()
    {
                                            //name        TimeEffect         IsAreaOfEffect              Stack
        {"Heal", new Potion(                "Heal",         3f,                true,                      3)},
        {"Speed", new Potion(              "Speed",          2f,                false,                    3)},
        {"InfinityAmmo", new Potion(    "InfinityAmmo",      5f,                true,                     2)}
    };
}
