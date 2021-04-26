using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening.Core.Easing;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [HideInInspector]public float currentScore;
    private int lastScore;
    public Text scoreText;
    private int floatingScore;
    public GameObject[] FloatingTextPrefabList;
    public GameObject target;
    public float offset;
    public static float HighestScore;
    public List<GameObject> Rank;
    private GameObject floatingText;


    void Awake()
    {
        instance = this;
        currentScore = 0;
        lastScore = 0;
        HighestScore = 0;
    }

    void Update()
    {
        if (currentScore < 0)
        {
            currentScore = 0;
        }
        scoreText.text=""+(int)currentScore;
        Debug.Log("Highest score is" + HighestScore);
        if (HighestScore!=0&&UITimer.instance.currentTime<=0)
        {
            Debug.Log($"currentscore:{currentScore}/highestscore:{HighestScore}/rankRatio:{currentScore/HighestScore}");
            if (currentScore / HighestScore <= 0.7)
            {
                Rank[0].gameObject.SetActive(true);
            }
            else if (currentScore / HighestScore > 0.7 && currentScore / HighestScore <= 0.8)
            {
                Rank[0].gameObject.SetActive(false);
                Rank[1].gameObject.SetActive(true);
            }
            else if (currentScore / HighestScore > 0.8 && currentScore / HighestScore <= 0.9)
            {
                Rank[1].gameObject.SetActive(false);
                Rank[2].gameObject.SetActive(true);
            }
            else if (currentScore / HighestScore > 0.9 && currentScore / HighestScore <= 0.95)
            {
                Rank[2].gameObject.SetActive(false);
                Rank[3].gameObject.SetActive(true);
            }
            else if (currentScore / HighestScore > 0.95 && currentScore / HighestScore <1)
            {
                Rank[3].gameObject.SetActive(false);
                Rank[4].gameObject.SetActive(true);
            }
            else if (currentScore / HighestScore == 1)
            {
                Rank[4].gameObject.SetActive(false);
                Rank[5].gameObject.SetActive(true);
            }

        }
       

       
    }
    public void AddScore(object _sender, EventArgs _e)
    {
       GameObject ai = _sender as GameObject;
       AIEventArgs e = _e as AIEventArgs;
       lastScore = (int)currentScore;
       floatingScore = ai.gameObject.GetComponent<AIBase>().myScore;
       currentScore += floatingScore;
        ShowFloatingText(ai);
    }

    void ShowFloatingText(GameObject _sender)
    {
        if (ComboSystem.comboPhase==0)
        {
            floatingText = Instantiate(FloatingTextPrefabList[0]);
        }

        if (ComboSystem.comboPhase == 1)
        {
            floatingText = Instantiate(FloatingTextPrefabList[1]);
        }

        if (ComboSystem.comboPhase == 2)
        {
            floatingText = Instantiate(FloatingTextPrefabList[2]);
        }

        if (ComboSystem.comboPhase == 3)
        {
            floatingText = Instantiate(FloatingTextPrefabList[3]);
        }
        floatingText.transform.position = _sender.transform.position+ new  Vector3(0,offset,0);
        floatingText.GetComponent<TextMesh>().text = floatingScore.ToString();
        //Instantiate(FloatingTextPrefab, _sender.transform.position,transform.rotation);
         floatingText.gameObject.transform.forward=floatingText.transform.position-target.transform.position;
    }

}
