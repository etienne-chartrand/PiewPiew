using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public GameObject gunPoint;

    public Camera mainCam;
    public LineRenderer lineRenderer;

    public Gun equippedGun;

    // Start is called before the first frame update
    void Start()
    {
        equippedGun = Gun.GunDictionary["Pistol"];
        lineRenderer = GetComponent<LineRenderer>();
        DisableLaser();
    }

    // Update is called once per frame
    void Update()
    {
        //Equipe l'arme voulu
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

        //Permet de tirer
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(BulletDelay());
        }

        //Si laser est equip
        if (Input.GetMouseButton(0) && equippedGun == Gun.GunDictionary["Laser"])
        {
            UpdateLaser();
        }

        //Si MachineGun est equip et on tir
        if(Input.GetMouseButtonDown(0) && equippedGun == Gun.GunDictionary["MachineGun"])
        {
            StartCoroutine(MachineGunShooting());
        }
        //Si le trigger de l'arme est lache arrete le tir
        if (Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
        }

        //Permet de fermer le laser
        if (Input.GetMouseButtonUp(0) && equippedGun == Gun.GunDictionary["Laser"])
        {
            DisableLaser();
        }
    }


    //MachineGun
    public IEnumerator MachineGunShooting()
    {
        //tir selon le nb de balle dans le mag
        for (int i = 0; i < equippedGun.BulletMag; i++)
        { 
           Rigidbody bullet;
           bullet = Instantiate(bulletPrefab, gunPoint.transform.position, transform.rotation) as Rigidbody;
           bullet.velocity = gunPoint.transform.forward * equippedGun.BulletSpeed;
           yield return new WaitForSeconds(equippedGun.BulletTimer);
        }  
    }

    //Armes et laser
    public IEnumerator BulletDelay()
    {
        //Check si arme a des balles
        if (equippedGun.HasBullet)
        {
            //tire selon le FireRate du Gun
            for (int i = 0; i < equippedGun.FireRate; i++)
            {
                Rigidbody bullet;
                bullet = Instantiate(bulletPrefab, gunPoint.transform.position, transform.rotation) as Rigidbody;
                bullet.velocity = gunPoint.transform.forward * equippedGun.BulletSpeed;
                yield return StartCoroutine(BulletTimer());
            }
        }
        else //active le laser
        {
            EnableLaser();
        }
    }

    //Timer qui attend pour que la prochian ne touche pas a celle qui vient detre tirer
    public IEnumerator BulletTimer()
    {
        float timer = equippedGun.BulletTimer;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }

    //Active le laser
    void EnableLaser()
    {
        lineRenderer.enabled = true;
    }

    //Desactive le laser
    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

    //Si on garde le laser enfoncer
    void UpdateLaser()
    {
        RaycastHit hit;

        //Reduit le laser si on hit un objet
        if (Physics.Raycast(transform.position, transform.forward, out hit, 15.3f))
        {
            hit.point = transform.InverseTransformPoint(hit.point);

            lineRenderer.SetPosition(1, hit.point);
            
        }
        else //Reset le laser si rien n'est toucher
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0.75f, 150f));
        }
    }
}
