using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialOrder : MonoBehaviour
{
    public bool haveHang;

    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
        haveHang = false;
    }

    public void Hanged()
    {
        haveHang = true;
    }
}
