using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;


public class MainMenu : RotatingButton
{

    protected override void OnTriggerStay(Collider col)
    {
        base.OnTriggerStay(col);
        if (V3Ope.BiggerV3(transform.localScale, new Vector3(ChangedScale - 0.01f, ChangedScale - 0.01f, ChangedScale - 0.01f)))
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


}

public static class V3Ope
{
    public static bool BiggerV3(Vector3 v1, Vector3 v2)
    {
        return v1.x > v2.x && v1.y > v2.y && v1.z > v2.z;
    }
}
