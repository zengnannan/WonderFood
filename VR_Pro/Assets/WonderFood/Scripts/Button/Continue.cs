﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<WangZi>() != null || col.GetComponent<Pan>() != null)
        {
            var index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index+1);
        }
    }

}
