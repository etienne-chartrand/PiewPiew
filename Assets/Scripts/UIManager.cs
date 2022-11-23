using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public CharacterMovement characterMovement;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (characterMovement.currentHealth <=0)
        {
            characterMovement.enabled=false;

            gameOverScreen.SetActive(true);
        }
    }
    
}
