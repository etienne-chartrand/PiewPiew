using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    public string GunName { get; set; }

    public int FireRate { get; set; }

    public int BulletSpeed { get; set; }

    public float BulletTimer { get; set; }

    public bool HasBullet { get; set; }

    public Gun()
    {
        this.GunName = "";
        this.FireRate = 0;
        this.BulletSpeed = 0;
        this.BulletSpeed = 0;
        this.HasBullet = true;
    }

    public Gun(string gunName, int fireRate, int bulletSpeed, float bulletTimer, bool hasBullet)
    {
        GunName = gunName;
        FireRate = fireRate;
        BulletSpeed = bulletSpeed;
        BulletTimer = bulletTimer;
        HasBullet = hasBullet;
    }

    public static Dictionary<string, Gun> GunDictionary = new Dictionary<string, Gun>()
    {
        //Identifier                 Name         FireRate  BulletSpeed     BulletTimer    HasBullet
        {"Pistol", new Gun(        "Pistol",         1,     100,               0,            true)},
        {"Famas", new Gun(         "Famas",          3,     200,              0.1f,          true)},
        {"ShotGun", new Gun(       "ShotGun",        5,     50,                0,            true)},
        {"MachineGun", new Gun(    "MachineGun",     1,     200,               0 ,           true)},
        {"Laser", new Gun(         "Laser",          0,     0,                 0,            false)}
    };

    

}
