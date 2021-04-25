using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class XRGUI : MonoBehaviour
{
    public GameObject LanguagePanel;
    public GameObject MainMenu;

    void Start()
    {
        LanguagePanel.SetActive(false);
    }
   public void LoadNewScene()
    {
        PlayerPrefs.SetInt("TutorialEnter",0);
        SceneManager.LoadScene(2);
        SoundManager.instance.PlaySound("UIClick");
    }

   public void Tutorial()
   {
       PlayerPrefs.SetInt("TutorialEnter", 1);
        LanguagePanel.SetActive(true);
       MainMenu.SetActive(false);
   }

   public void Quit()
   {
       Application.Quit();
   }

   public void ChineseButton()
   {
        // ChineseVersion= true;
        PlayerPrefs.SetInt("Language",0);
        SceneManager.LoadScene(1);
    }

   public void EnglishButton()
   {
       // EnglishVersion= true;
       PlayerPrefs.SetInt("Language", 1);
       SceneManager.LoadScene(1);
    }

}
