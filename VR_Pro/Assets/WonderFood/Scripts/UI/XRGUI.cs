using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class XRGUI : MonoBehaviour
{
   public void LoadNewScene()
    {
        SceneManager.LoadScene(1);
        SoundManager.instance.PlaySound("UIClick");
    }
    

   
}
