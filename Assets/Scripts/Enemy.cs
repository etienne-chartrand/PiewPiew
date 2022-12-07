using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string EnemyName { get; set; }

    public int EnemyHealth { get; set; }

    public Gun EnemyGun { get; set; }

    public float EnemySpeed { get; set; }

    public Enemy()
    {
        this.EnemyName = "";
        this.EnemyHealth = 0;
        this.EnemyGun = new Gun();
        this.EnemySpeed = 0f;
    }

    public Enemy(string enemyName, int enemyhealth, Gun enemyGun, float enemySpeed)
    {
        EnemyName = enemyName;
        EnemyHealth = enemyhealth;
        EnemyGun = enemyGun;
        EnemySpeed = enemySpeed;
    }

    public static Dictionary<string, Enemy> EnemyDictionary = new Dictionary<string, Enemy>()
    {
                                     //Name          Health              Weapon                              Speed
        { "Stabber", new Enemy(     "Stabber",        100,       Gun.GunDictionary["Pistol"],                3.5f)},
        { "Shooter", new Enemy(     "Shooter",         80,       Gun.GunDictionary["Famas"],                  2f)},
        { "Dentist", new Enemy(     "Dentist",        800,       Gun.GunDictionary["Shotgun"],                2.5f)}
    };
}
