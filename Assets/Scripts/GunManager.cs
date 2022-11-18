using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public GameObject gunPoint;
    public int bulletForce;


    private int balleCree;
    public int FireRate;
    public float timeBetweenBullets;

    int[] FireRateArray = { 1, 10, 20 };
    int[] bulletForceArray = { 150, 200, 50 };
    float[] timeArray = { 0, 0.1f, 0 };

    public Gun equippedGun;

    public int arrayIndex;
    // Start is called before the first frame update
    void Start()
    {
        equippedGun = Gun.GunDictionary["Pistol"];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equippedGun = Gun.GunDictionary["Pistol"];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equippedGun = Gun.GunDictionary["Famas"];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            equippedGun = Gun.GunDictionary["ShotGun"];
        }

        if (Input.GetMouseButtonDown(0))
        {
           
            StartCoroutine(BulletDelay());
        }
    }

    public IEnumerator BulletDelay()
    {
        for (int i = 0; i < equippedGun.FireRate; i++)
        {
            Rigidbody bullet;
            bullet = Instantiate(bulletPrefab, gunPoint.transform.position, transform.rotation) as Rigidbody;
            //bullet.velocity = transform.TransformDirection(gunPoint.transform.forward * equippedGun.BulletSpeed);  Fonction TransformDirection Convertit local to WorldSpace(donc pas bon)
            bullet.velocity = gunPoint.transform.forward * equippedGun.BulletSpeed;
            yield return StartCoroutine(BulletTimer());
        }
    }

    public IEnumerator BulletTimer()
    {
        float timer = equippedGun.BulletTimer;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }
}
