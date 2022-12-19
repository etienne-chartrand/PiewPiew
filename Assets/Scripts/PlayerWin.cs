using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    private GameObject UIManagerGO;
    private UIManager UIManager;

    private void Start()
    {
        UIManagerGO = GameObject.FindWithTag("UIManager");
        UIManager = UIManagerGO.GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UIManager.PlayerWin();
        }
    }
}
