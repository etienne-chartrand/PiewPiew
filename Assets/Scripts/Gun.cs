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

    public int BulletMag { get; set; }

    public Gun()
    {
        this.GunName = "";
        this.FireRate = 0;
        this.BulletSpeed = 0;
        this.BulletSpeed = 0;
        this.HasBullet = true;
        this.BulletMag = 0;
    }

    public Gun(string gunName, int fireRate, int bulletSpeed, float bulletTimer, bool hasBullet, int bulletMag)
    {
        GunName = gunName;
        FireRate = fireRate;
        BulletSpeed = bulletSpeed;
        BulletTimer = bulletTimer;
        HasBullet = hasBullet;
        BulletMag = bulletMag;
    }

    public static Dictionary<string, Gun> GunDictionary = new Dictionary<string, Gun>()
    {
        //Identifier                 Name         FireRate  BulletSpeed     BulletTimer    HasBullet      bulletMag
        {"Pistol", new Gun(        "Pistol",         1,     100,               0,            true,           12)},
        {"Famas", new Gun(         "Famas",          3,     200,              0.1f,          true,           30)},
        {"ShotGun", new Gun(       "ShotGun",        5,     50,                0,            true,            6)},
        {"MachineGun", new Gun(    "MachineGun",     1,     200,               0.05f,         true,           200)},
        {"Laser", new Gun(         "Laser",          0,     0,                 0,            false,           0)}
    };

    

}
