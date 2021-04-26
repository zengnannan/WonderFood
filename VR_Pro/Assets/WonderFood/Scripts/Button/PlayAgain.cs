using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class PlayAgain : RotatingButton
{

    protected override void OnTriggerStay(Collider col)
    {
        base.OnTriggerStay(col);
        if (V3Ope.BiggerV3(transform.localScale, new Vector3(ChangedScale - 0.01f, ChangedScale - 0.01f, ChangedScale - 0.01f)))
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
                    if (SceneManager.GetActiveScene().name == "NewLevel6")
                    {
                        if (doOnce)
                        {
                            doOnce = false;
                            PlayerPrefs.SetFloat("PlayerScore", FinalScore.lastPlayerScore);
                            PlayerPrefs.SetFloat("SystemScore", FinalScore.lastHighestScore);
                            
                        }

                    }
                    SceneManager.LoadScene(index);
                }
            }
        }
    }

}
