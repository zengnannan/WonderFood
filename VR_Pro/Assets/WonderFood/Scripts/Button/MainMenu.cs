using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<WangZi>() != null || col.GetComponent<Pan>() != null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
