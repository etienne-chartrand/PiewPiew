using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    //Classe de gun avec differentes variables
    public string GunName { get; set; }

    public int FireRate { get; set; }

    public int BulletSpeed { get; set; }

    public float BulletTimer { get; set; }

    public bool HasBullet { get; set; }

    public int MaxBulletMag { get; set; }

    public int CurrentBulletMag { get; set; }

    public float ReloadTimer { get; set; }

    public Gun()
    {
        this.GunName = "";
        this.FireRate = 0;
        this.BulletSpeed = 0;
        this.BulletSpeed = 0;
        this.HasBullet = true;
        this.MaxBulletMag = 0;
        this.CurrentBulletMag = 0;
        this.ReloadTimer = 0;
    }

    public Gun(string gunName, int fireRate, int bulletSpeed, float bulletTimer, bool hasBullet, int maxBulletMag, int currentBulletMag, float reloadTimer)
    {
        GunName = gunName;
        FireRate = fireRate;
        BulletSpeed = bulletSpeed;
        BulletTimer = bulletTimer;
        HasBullet = hasBullet;
        MaxBulletMag = maxBulletMag;
        CurrentBulletMag = currentBulletMag;
        ReloadTimer = reloadTimer;
    }

    //Types de gun
    public static Dictionary<string, Gun> GunDictionary = new Dictionary<string, Gun>()
    {
        //Identifier                 Name         FireRate  BulletSpeed     BulletTimer    HasBullet      maxBulletMag    CurrentBulletMag      ReloadTimer
        {"Pistol", new Gun(        "Pistol",         1,     50,               0,            true,           12,               12,                 1f)},
        {"Famas", new Gun(         "Famas",          3,     200,              0.05f,          true,           30,               30,                 1.4f)},
        {"ShotGun", new Gun(       "ShotGun",        6,     50,                0,            true,            36,                36,                 1.5f)},
        {"MachineGun", new Gun(    "MachineGun",     1,     200,               0.03f,         true,           200,             200,                2.7f)},
        {"Laser", new Gun(         "Laser",          0,     0,                 0,            false,           0,                0,                 0)}
    };

    

}
