using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;


public class UIManager : MonoBehaviour
{
    private UIObjectNum uiobjectnum;
    public int completeNum;
    public GameObject successPanel;
    public GameObject failPanel;
    private XRRayInteractor[] xrRays;
    public Text successScore;
    public Text failScore;

    private TutorialBoard endBoard;

    private bool doOnce;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        endBoard = FindObjectOfType<TutorialBoard>();
        uiobjectnum = FindObjectOfType<UIObjectNum>();
        completeNum = 0;
        successPanel.SetActive(false);
        failPanel.SetActive(false);
        xrRays = FindObjectsOfType<XRRayInteractor>();
        foreach (var xrRayInteractor in xrRays)
        {
            xrRayInteractor.enabled = false;
        }

        doOnce = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Go into GameOver
        if (UITimer.instance.isGameOver && doOnce == false)
        {
            doOnce = true;
            //BoardGoingDown
            endBoard.GoingDown();
            
            //see how many object players finished
            for (int i = 0; i < uiobjectnum.ObjectName.Length; i++)
            {
                Debug.Log("Enter fun1");
                if (uiobjectnum.currentObjectNum[i] <= 0)
                {
                    Debug.Log("Enter fuc2");
                    completeNum++;
                }
            }

            //Success
            if (completeNum == uiobjectnum.ObjectName.Length)
            {
                successPanel.SetActive(true);
                successPanel.GetComponent<Animator>().SetTrigger("Success");
            }
            else//Lose
            {
                failPanel.SetActive(true);
                Debug.Log("fail");
                failPanel.GetComponent<Animator>().SetTrigger("Success");
            }

            
        }


    }

    public void PlayAgain()
    {
        SoundManager.instance.PlaySound("UIClick");
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);

    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySound("UIClick");
        Application.Quit();

    }

    public void NextLevel()
    {
        SoundManager.instance.PlaySound("UIClick");
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}
