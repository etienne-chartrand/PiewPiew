using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//display du chargeur
public class BulletCount : MonoBehaviour
{
    public TMP_Text bulletCount;

    //Reset le text lorsque change d'arme/reload
    public void SetBulletCount(int bulletInMag)
    {
        bulletCount.text = bulletInMag.ToString();
    }
}
