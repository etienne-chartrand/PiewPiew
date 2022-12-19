using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public PotionManager potionManager;

    //HealthSystem
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private bool canTakeDamage;

    //SpeedSystem
    private float playerSpeed; //player speed
    private float speed = 500f; // Speed variable
    private float speedEffectPotion = 850f; //speed when taking a potion


    public Rigidbody rb; // Set the variable 'rb' as Rigibody
    public Vector3 movement; // Set the variable 'movement' as a Vector3 (x,y,z)

    //Camera
    private Camera mainCam;

    public bool jeuFini;

    //DashSystem
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 32f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    // Sound
    public AudioSource Hurt;

    //Set les variables de base
    void Start()
    {
        playerSpeed = speed;
        canTakeDamage = true;
        jeuFini = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = this.GetComponent<Rigidbody>();

        mainCam = Camera.main;
    }


    void Update()
    {
        //if (isDashing)
        //{
        //    return;
        //}


        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    TakeDamage(20);
        //}

        //Axe de movement
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;


        //DASH
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        //Permet de heal
        if (Input.GetKeyDown(KeyCode.Q))
        {
            potionManager.ConsumePotion(PotionManager.PotionType.Heal);
        }

        //Permet de speed
        if (Input.GetKeyDown(KeyCode.F))
        {
            potionManager.ConsumePotion(PotionManager.PotionType.Speed);
        }

        //Permet d'avoir infinityAmmo
        if (Input.GetKeyDown(KeyCode.X))
        {
            potionManager.ConsumePotion(PotionManager.PotionType.InfinityAmmo);
        }
    }

    //Player prends du damage selon le nb qu'on veut
    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            Hurt.Play();
        }
    }

    //Heal potion
    public void HealPlayer(int totalHeal, float time)
    {
        StartCoroutine(Healing(totalHeal, time));
    }
    //Arrete le heal
    public void StopHealing()
    {
        StopCoroutine(Healing(0,0f));
    }
    //Heal
    private IEnumerator Healing(int heal, float time)
    {
        if (currentHealth < maxHealth)
        {
            WaitForSeconds wfs = new WaitForSeconds(1);
            
            for (int i = 0; i < time; i++)
            {
                currentHealth += heal;
                healthBar.SetHealth(currentHealth);
                yield return wfs;
            }
        }
    }

    //Speed potion
    public void SpeedPotionEffect(float time)
    {
        StartCoroutine(SpeedPlayer(time));
    }
    //SPEED
    private IEnumerator SpeedPlayer(float time)
    {
        WaitForSeconds wfs = new WaitForSeconds(time);
        playerSpeed = speedEffectPotion;
        yield return wfs;
        playerSpeed = speed;
    }


    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        moveCharacter(movement); // We call the function 'moveCharacter' in FixedUpdate for Physics movement

        //Player rotate selon l'endroit de la souris
        Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }
    }



    // 'moveCharacter' Function for moving the game object
    void moveCharacter(Vector3 direction)
    {
        // We multiply the 'speed' variable to the Rigidbody's velocity...
        // and also multiply 'Time.fixedDeltaTime' to keep the movement consistant on all devices
        rb.velocity = direction * playerSpeed * Time.fixedDeltaTime;
    }

    //DASH
    private IEnumerator Dash()
    {
        canDash = false;
        canTakeDamage = false;
        isDashing = true;
        rb.velocity = new Vector3(movement.x * dashingPower, 0, movement.z * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        canTakeDamage = true;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fin")
        {
            jeuFini = true;
        }
    }
}
