using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public GameObject gunPoint;
    public int bulletForce;

    public Camera mainCam;
    public LineRenderer lineRenderer;

    public Gun equippedGun;
    private bool isShooting;

    public int arrayIndex;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        equippedGun = Gun.GunDictionary["Pistol"];
        lineRenderer = GetComponent<LineRenderer>();
        DisableLaser();
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

        if (Input.GetMouseButton(0) && equippedGun == Gun.GunDictionary["Laser"])
        {
            UpdateLaser();
        }

        if(Input.GetMouseButton(0) && equippedGun == Gun.GunDictionary["MachineGun"])
        {
            while (isShooting)
            {

            }

            if (!isShooting)
            {
                isShooting = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }

        if (Input.GetMouseButtonUp(0) && equippedGun == Gun.GunDictionary["Laser"])
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
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 15.3f))
        {
            hit.point = transform.InverseTransformPoint(hit.point);

            lineRenderer.SetPosition(1, hit.point);
            
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0.75f, 150f));
        }
    }
}
