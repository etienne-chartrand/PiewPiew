using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public GameObject gunPoint;
    public int bulletForce;

    public LineRenderer lineRenderer;


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
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            equippedGun = Gun.GunDictionary["MachineGun"];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            equippedGun = Gun.GunDictionary["Laser"];
        }


        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(BulletDelay());
        }

        if (Input.GetMouseButton(0))
        {
            UpdateLaser();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DisableLaser();
        }
    }

    public IEnumerator BulletDelay()
    {
        if (equippedGun.HasBullet)
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
        else
        {
            EnableLaser();
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

    void EnableLaser()
    {
        lineRenderer.enabled = true;
    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

    void UpdateLaser()
    {
        
    }
}
