using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObjectNum : MonoBehaviour
{
    public static UIObjectNum instance;

    [Header("The name of Objectives you need to collect")]
    public String[] ObjectName;
    [Header("How many Objectives you have collected")]
    public int[] currentObjectNum;
    public Text[] currentObjectTextArray;
    [Header("The requirement of these Objectives")]
    public int[] requireObjectNum;
    void Start()
     {
         instance = this;
        //开局时重置current object num
        for (int i = 0; i < currentObjectNum.Length; i++)
        {
            currentObjectNum[i] = requireObjectNum[i];
        }

    }

     void Update()
    {
        for (int i = 0; i < currentObjectTextArray.Length; i++)
        {
            if (currentObjectNum[i] >0)
            {
               currentObjectTextArray[i].text = currentObjectNum[i].ToString(); 
            }
            
        }
    }

     public void AddObjectiveNum(object _sender, EventArgs _e)
     {
         GameObject ai = _sender as GameObject;
         AIEventArgs e = _e as AIEventArgs;

         for (int i = 0; i < currentObjectNum.Length; i++)
         {
             if (e.poolName == ObjectName[i])
             {
                 currentObjectNum[i]--;
                 if (currentObjectNum[i] == 0)
                 {
                     currentObjectTextArray[i].text = "√";
                 }
             }
         }
    }


}
