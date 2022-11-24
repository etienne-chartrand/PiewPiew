using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCount : MonoBehaviour
{
    public TMP_Text bulletCount;

    public void SetBulletCount(int bulletInMag)
    {
        bulletCount.text = bulletInMag.ToString();
    }
}
