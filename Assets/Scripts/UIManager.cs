using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public CharacterMovement characterMovement;

    public GameObject gameOverScreen;

    public GameObject winScreen;

    public GameObject Music;

    public GameObject gunSelection;
    public static int selectedGun;

    public Color selected;
    public Color unSelected;

    public AudioSource Loosing;

    public AudioClip loose;

    public bool isDead;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        gameOverScreen.SetActive(false);

        winScreen.SetActive(false);
        SelectGun(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (characterMovement.currentHealth <=0)
        {
            characterMovement.enabled = false;

            gameOverScreen.SetActive(true);

            isDead = true;

            Destroy(GameObject.FindWithTag("Music"));

            
          
        }
        if(characterMovement.jeuFini == true)
        { 
            winScreen.SetActive(true);

            won = true;

            characterMovement.enabled = false;

            Destroy(GameObject.FindWithTag("Music"));
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("PiewPiew");
    }

    //Selectionne le bon gun dans le ui
    public void SelectGun(int gunSelected)
    {
        for(int i = 0; i < gunSelection.transform.childCount; i++)
        {
            if(i == gunSelected - 1)
            {
                gunSelection.transform.GetChild(i).GetComponent<Image>().color = selected;
            }
            else
            {
                gunSelection.transform.GetChild(i).GetComponent<Image>().color = unSelected;
            }
        }
    }
}
