using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialOrder : MonoBehaviour
{
    public bool haveHang;

    void Awake()
    {
        haveHang = false;
    }

    public void Hanged()
    {
        haveHang = true;
    }
}
