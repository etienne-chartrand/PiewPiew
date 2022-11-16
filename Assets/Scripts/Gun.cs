using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    public string GunName { get; set; }

    public int FireRate { get; set; }

    public int BulletSpeed { get; set; }

    public float BulletTimer { get; set; }

    public Gun()
    {
        this.GunName = "";
        this.FireRate = 0;
        this.BulletSpeed = 0;
        this.BulletSpeed = 0;
    }

    public Gun(string gunName, int fireRate, int bulletSpeed, float bulletTimer)
    {
        GunName = gunName;
        FireRate = fireRate;
        BulletSpeed = bulletSpeed;
        BulletTimer = bulletTimer;
    }

    public static Dictionary<string, Gun> GunDictionary = new Dictionary<string, Gun>()
    {
        //Identifier        Name      FireRate  BulletSpeed     BulletTimer
        {"Pistol", new Gun("Pistol",       1,     100,           0)},
        {"Famas", new Gun("Famas",         10,     200,          0.1f)},
        {"ShotGun", new Gun("ShotGun",         5,     50,          0)}
    };

}
