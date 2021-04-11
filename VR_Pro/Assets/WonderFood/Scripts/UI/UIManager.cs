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

    private bool doOnce;

    // Start is called before the first frame update
    protected virtual void Start()
    {
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
        if (UITimer.instance.currentTime <= 0f && doOnce == false)
        {
            doOnce = true;
            for (int i = 0; i < uiobjectnum.ObjectName.Length; i++)
            {
                Debug.Log("Enter fun1");
                if (uiobjectnum.currentObjectNum[i] >= uiobjectnum.requireObjectNum[i])
                {
                    Debug.Log("Enter fuc2");
                    completeNum++;
                }
            }

            foreach (var xrRayInteractor in xrRays)
            {
                xrRayInteractor.enabled = true;
            }


            if (completeNum == uiobjectnum.ObjectName.Length)
            {
                Debug.Log("sucess");
                successPanel.SetActive(true);
                successScore.text = ScoreManager.instance.currentScore.ToString();
            }
            else
            {
                Debug.Log("fail");
                failPanel.SetActive(true);
                failScore.text = ScoreManager.instance.currentScore.ToString();
            }

            Time.timeScale = 0;
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
