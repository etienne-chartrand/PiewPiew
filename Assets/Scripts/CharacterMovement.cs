using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //HealthSystem
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private bool canTakeDamage;


    // Add the variables
    public float speed = 100f; // Speed variable
    public Rigidbody rb; // Set the variable 'rb' as Rigibody
    public Vector3 movement; // Set the variable 'movement' as a Vector3 (x,y,z)

    //Camera
    private Camera mainCam;

    public bool jeuFini;

    //Dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 32f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;



    void Start()
    {
        canTakeDamage = true;
        jeuFini = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // find the Rigidbody of this game object and add it to the variable 'rb'
        rb = this.GetComponent<Rigidbody>();

        mainCam = Camera.main;
    }


    void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }

        // In Update we get the Input for left, right, up and down and put it in the variable 'movement'...
        // We only get the input of x and z, y is left at 0 as it's not required
        // 'Normalized' diagonals to prevent faster movement when two inputs are used together
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;


        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    //Player prends du damage
    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
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
            //Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }
    }



    // 'moveCharacter' Function for moving the game object
    void moveCharacter(Vector3 direction)
    {
        // We multiply the 'speed' variable to the Rigidbody's velocity...
        // and also multiply 'Time.fixedDeltaTime' to keep the movement consistant on all devices
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }

    //Dash
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
