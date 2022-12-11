using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string EnemyName { get; set; }

    public int EnemyHealth { get; set; }

    public Gun EnemyGun { get; set; }

    public float EnemySpeed { get; set; }

    public float EnemyStoppingDistance { get; set; }

    public float EnemyShootingDistance { get; set; }

    public Enemy()
    {
        this.EnemyName = "";
        this.EnemyHealth = 0;
        this.EnemyGun = new Gun();
        this.EnemySpeed = 0f;
        this.EnemyStoppingDistance= 0f;
        this.EnemyShootingDistance = 0f;
    }

    public Enemy(string enemyName, int enemyhealth, Gun enemyGun, float enemySpeed, float enemyStoppingDistance, float enemyShootingDistance)
    {
        EnemyName = enemyName;
        EnemyHealth = enemyhealth;
        EnemyGun = enemyGun;
        EnemySpeed = enemySpeed;
        EnemyStoppingDistance= enemyStoppingDistance;
        EnemyShootingDistance = enemyShootingDistance;
    }

    public static Dictionary<string, Enemy> EnemyDictionary = new Dictionary<string, Enemy>()
    {
                                     //Name          Health              Weapon                              Speed          StoppingDistance         ShootingDistance
        { "Stabber", new Enemy(     "Stabber",        100,       Gun.GunDictionary["Pistol"],                3.5f,               0,                         2f)},
        { "Shooter", new Enemy(     "Shooter",         80,       Gun.GunDictionary["Famas"],                  2f,                5f,                        14f)},
        { "Dentist", new Enemy(     "Dentist",        800,       Gun.GunDictionary["ShotGun"],                2.5f,              7f,                        18f)}
    };
}
