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
        
        SceneManager.LoadScene("NewLevel1Button");
        SoundManager.instance.PlaySound("UIClick");
    }

   public void Tutorial()
   {
       
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
        SceneManager.LoadScene("Tutorial");
    }

   public void EnglishButton()
   {
       // EnglishVersion= true;
       PlayerPrefs.SetInt("Tutorial",1);
    }

}
