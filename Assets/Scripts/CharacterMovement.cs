using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //HealthSystem
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;


    // Add the variables
    public float speed = 100f; // Speed variable
    public Rigidbody rb; // Set the variable 'rb' as Rigibody
    public Vector3 movement; // Set the variable 'movement' as a Vector3 (x,y,z)



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // find the Rigidbody of this game object and add it to the variable 'rb'
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    TakeDamage(20);
        //}

        // In Update we get the Input for left, right, up and down and put it in the variable 'movement'...
        // We only get the input of x and z, y is left at 0 as it's not required
        // 'Normalized' diagonals to prevent faster movement when two inputs are used together
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }



    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        moveCharacter(movement); // We call the function 'moveCharacter' in FixedUpdate for Physics movement
    }



    // 'moveCharacter' Function for moving the game object
    void moveCharacter(Vector3 direction)
    {
        // We multiply the 'speed' variable to the Rigidbody's velocity...
        // and also multiply 'Time.fixedDeltaTime' to keep the movement consistant on all devices
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
