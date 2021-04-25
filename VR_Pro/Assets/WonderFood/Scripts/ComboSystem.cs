using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ComboSystem : MonoBehaviour
{
    public static ComboSystem instance;
    [Header("ComboNum")]
    public int lastComboNum;
    public int currentComboNum;
    [Header("MaxCombo")]
    public int MaxComboNum;
    [HideInInspector]public float comboRatio;
    public Text comboNumText;
    public Text MaxComboText;

    private Animator anim;
    private bool doOnce;
    [HideInInspector] public static int comboPhase;
    

    private void Start()
    {
        instance = this;
        lastComboNum = 0;
        currentComboNum = 0;
        MaxComboNum = currentComboNum;
        anim = GetComponent<Animator>();
        doOnce = false;
    }

    void Update()
    {
        #region ComboNum
        //ComboNum
        comboNumText.text = currentComboNum.ToString();
        
        if (lastComboNum == currentComboNum)
        {
            anim.SetBool("ComboState", false);
        }

        if (lastComboNum > currentComboNum)
        {
            if (doOnce)
            {
              anim.SetTrigger("StopCombo");
              anim.SetBool("ComboState", false);
            }

            doOnce = false;
        }

        if (lastComboNum < currentComboNum)
        {
            anim.SetBool("ComboState",true);
            doOnce = true;
        }
        #endregion



        if (currentComboNum >= 0 && currentComboNum < 2)
        {
            Debug.Log(currentComboNum);
            comboRatio = 1f;
            comboPhase = 0;
        }
        else if (currentComboNum >= 2 && currentComboNum < 4)
        {
            comboRatio = 1.2f;
            comboPhase = 1;

        }
        else if (currentComboNum >= 4 && currentComboNum < 8)
        {
            comboRatio = 1.5f;
            comboPhase = 2;
            //comboRatioText.text = "<color=orange>" + "X " + "</color>" + (4);
        }
        else if (currentComboNum >= 8)
        {
            comboRatio = 2f;
            comboPhase = 3;
            //comboRatioText.text = "<color=orange>" + "X " + "</color>" + (8);
        }

        if (currentComboNum > MaxComboNum)
        {
            MaxComboNum = currentComboNum;
        }

        MaxComboText.text = MaxComboNum.ToString();

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

        lastComboNum = currentComboNum;
        currentComboNum = 0;
    }
}
