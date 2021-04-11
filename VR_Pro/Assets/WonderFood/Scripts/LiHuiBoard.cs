using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiHuiBoard : MonoBehaviour
{

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void Launch()
    {
        Launcher.instance.Shoot();
    }

    private void Disppear()
    {
        this.gameObject.SetActive(false);
    }
  
}
