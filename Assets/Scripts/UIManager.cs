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

    public GameObject gunSelection;
    public static int selectedGun;

    public Color selected;
    public Color unSelected;

    // Start is called before the first frame update
    void Start()
    {
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
        }
        if(characterMovement.jeuFini == true)
        { 
            winScreen.SetActive(true);

            characterMovement.enabled = false;
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
