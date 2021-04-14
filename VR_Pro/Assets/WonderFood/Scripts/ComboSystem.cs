using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ComboSystem : MonoBehaviour
{
    public static ComboSystem instance;
    public int lastComboNum;
    public int currentComboNum;
    public int MaxComboNum;
    public float comboRatio;
    public Text comboRatioText;
    public Text comboNumText;

    private void Start()
    {
        instance = this;
        lastComboNum = 0;
        currentComboNum = 0;
        comboRatioText.gameObject.SetActive(false);
        MaxComboNum = currentComboNum;
    }

    void Update()
    {
        comboNumText.text = currentComboNum.ToString();
        
        if (currentComboNum>=0&&currentComboNum<2)
        {
            comboRatio = 1f;
            comboRatioText.gameObject.SetActive(false);
        }
        else if (currentComboNum>=2&&currentComboNum<4)
        {
            comboRatio = 1.2f;
            comboRatioText.gameObject.SetActive(true);
            comboRatioText.text = "<color=orange>" + "X " + "</color>" + (2);
        }
        else if (currentComboNum>=4&&currentComboNum<8)
        {
            comboRatio = 1.5f;
            comboRatioText.text = "<color=orange>" + "X " + "</color>" + (4);
        }
        else if (currentComboNum>=8)
        {
            comboRatio = 2f;
            comboRatioText.text = "<color=orange>" + "X " + "</color>" + (8);
        }

        if(currentComboNum>MaxComboNum)
        {
            MaxComboNum = currentComboNum;
        }
  
    }

    
    public void AddComboNum(object _sender, EventArgs _e)
    {
        GameObject ai = _sender as GameObject;
        AIEventArgs e = _e as AIEventArgs;

        lastComboNum = currentComboNum;
        currentComboNum++;
    }

    public void ResetComboNum(object _sender, EventArgs _e)
    {
        GameObject ai = _sender as GameObject;
        AIEventArgs e = _e as AIEventArgs;

        lastComboNum = 0;
        currentComboNum = 0;
    }
}
