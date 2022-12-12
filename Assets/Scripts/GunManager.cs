using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public GameObject gunPoint;
    public BulletCount bulletCount;

    public Camera mainCam;
    public LineRenderer lineRenderer;

    public Gun equippedGun;
    public UIManager uiManager;


    public bool infinityAmmoEffect;
    private bool isReloading = false;

    public LayerMask layerMask;

    private void Awake()
    {
        gunPoint = this.gameObject;
        equippedGun = Gun.GunDictionary["Pistol"];
    }

    // Start is called before the first frame update
    void Start()
    {
        infinityAmmoEffect = false;
        mainCam = Camera.main;
        bulletCount.SetBulletCount(equippedGun.MaxBulletMag);
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
            bulletCount.SetBulletCount(equippedGun.CurrentBulletMag);
            uiManager.SelectGun(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equippedGun = Gun.GunDictionary["Famas"];
            bulletCount.SetBulletCount(equippedGun.CurrentBulletMag);
            uiManager.SelectGun(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            equippedGun = Gun.GunDictionary["ShotGun"];
            bulletCount.SetBulletCount(equippedGun.CurrentBulletMag);
            uiManager.SelectGun(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            equippedGun = Gun.GunDictionary["MachineGun"];
            bulletCount.SetBulletCount(equippedGun.CurrentBulletMag);
            uiManager.SelectGun(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            equippedGun = Gun.GunDictionary["Laser"];
            bulletCount.SetBulletCount(equippedGun.CurrentBulletMag);
            uiManager.SelectGun(5);
        }

        if (!isReloading)
        {
            //Permet de tirer
            if (Input.GetMouseButtonDown(0) && equippedGun != Gun.GunDictionary["MachineGun"])
            {
                StartCoroutine(BulletDelay());
            }

            //Si laser est equip
            if (Input.GetMouseButton(0) && equippedGun == Gun.GunDictionary["Laser"])
            {
                UpdateLaser();
            }

            //Si MachineGun est equip et on tir
            if (Input.GetMouseButtonDown(0) && equippedGun == Gun.GunDictionary["MachineGun"])
            {
                StartCoroutine(MachineGunShooting());
            }

            //Permet de fermer le laser
            if (Input.GetMouseButtonUp(0) && equippedGun == Gun.GunDictionary["Laser"])
            {
                DisableLaser();
            }
        }

        //Si le trigger de l'arme est lache arrete le tir
        if (Input.GetMouseButtonUp(0) && equippedGun == Gun.GunDictionary["MachineGun"])
        {
            StopAllCoroutines();
        }

        //Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }


    //MachineGun
    public IEnumerator MachineGunShooting()
    {
        WaitForSeconds wfs = new WaitForSeconds(1f);
        yield return wfs;

        //tir selon le nb de balle dans le mag
        for (int i = 0; i < equippedGun.MaxBulletMag; i++)
        {
            if (!infinityAmmoEffect)
            {
                equippedGun.CurrentBulletMag--;
            }
            
            Rigidbody bullet;
            bullet = Instantiate(bulletPrefab, gunPoint.transform.position, transform.rotation) as Rigidbody;
            bullet.velocity = gunPoint.transform.forward * equippedGun.BulletSpeed;
            bulletCount.SetBulletCount(equippedGun.CurrentBulletMag);
            yield return new WaitForSeconds(equippedGun.BulletTimer);

            if(equippedGun.CurrentBulletMag <= 0)
            {
                break;
            }
        } 
    }

    //Armes et laser
    public IEnumerator BulletDelay()
    {
        //Check si arme utilise des balles
        if (equippedGun.HasBullet)
        {
            if(equippedGun.CurrentBulletMag > 0)
            {
                //tire selon le FireRate du Gun
                for (int i = 0; i < equippedGun.FireRate; i++)
                {
                    if (!infinityAmmoEffect)
                    {
                        equippedGun.CurrentBulletMag--;
                    }
                    Rigidbody bullet;
                    bullet = Instantiate(bulletPrefab, gunPoint.transform.position, transform.rotation) as Rigidbody;
                    bullet.velocity = gunPoint.transform.forward * equippedGun.BulletSpeed;
                    bulletCount.SetBulletCount(equippedGun.CurrentBulletMag);
                    yield return StartCoroutine(BulletTimer());
                }
            }
        }
        else //active le laser
        {
            EnableLaser();
        }
    }

    //Timer qui attend pour que la prochain ne touche pas a celle qui vient detre tirer
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
        if (Physics.Raycast(transform.position, transform.forward, out hit, 15.3f, layerMask ,QueryTriggerInteraction.Ignore))
        {
            Debug.Log("yo");
            if (hit.collider.tag == "Enemy")
            {
                EnemyBehaviour enemy = hit.collider.gameObject.GetComponent<EnemyBehaviour>();
                enemy.TakeDamage(.15f);
            }
            else
            {
                hit.point = transform.InverseTransformPoint(hit.point);
                lineRenderer.SetPosition(1, hit.point);
            }
            
        }
        else //Reset le laser si rien n'est toucher
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0.75f, 150f));
        }
    }

    //ReloadGun
    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(equippedGun.ReloadTimer);
        equippedGun.CurrentBulletMag = equippedGun.MaxBulletMag;
        bulletCount.SetBulletCount(equippedGun.CurrentBulletMag);
        isReloading = false;

    }
}
