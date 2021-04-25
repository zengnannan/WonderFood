using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;


public class MainMenu : RotatingButton
{
    protected override void Update()
    {
        base.Update();
    }

    void OnTriggerEnter(Collider col)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            var tutorial = FindObjectOfType<NewTutorial>();
            if (col.GetComponent<WangZi>() != null || col.GetComponent<Pan>() != null)
            {
                if (tutorial.finishedTenVoice == true)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }

        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (col.GetComponent<WangZi>() != null || col.GetComponent<Pan>() != null)
            {
                SceneManager.LoadScene(0);
            }
        }

    }
}
