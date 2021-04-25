using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class PlayAgain : RotatingButton
{
    void OnTriggerEnter(Collider col)
    {
        //replay tutorial
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            var tutorial = FindObjectOfType<NewTutorial>();
            if (col.GetComponent<WangZi>() != null || col.GetComponent<Pan>() != null)
            {
                if (tutorial.finishedTenVoice == true)
                {
                    SceneManager.LoadScene(1);
                }

            }
        }

        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (col.GetComponent<WangZi>() != null || col.GetComponent<Pan>() != null)
            {
                var index = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("TutorialEnter", 0);
                SceneManager.LoadScene(index);
            }
        }

    }

}
