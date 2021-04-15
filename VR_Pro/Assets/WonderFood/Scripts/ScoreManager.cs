using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [HideInInspector]public float currentScore;
    private int lastScore;
    public Text scoreText;
    public Text RankText;
    private int floatingScore;
    public GameObject FloatingTextPrefab;
    public GameObject target;
    public float offset;
    public static float HighestScore;
    public string Rank;


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
        if (HighestScore!=0)
        {
            Debug.Log($"currentscore:{currentScore}/highestscore:{HighestScore}/rankRatio:{currentScore/HighestScore}");
            if (currentScore / HighestScore <= 0.7)
            {
                Rank = "C";
            }
            else if (currentScore / HighestScore > 0.7 && currentScore / HighestScore <= 0.8)
            {

                Rank = "B";
            }
            else if (currentScore / HighestScore > 0.8 && currentScore / HighestScore <= 0.9)
            {
                Rank = "A";
            }
            else if (currentScore / HighestScore > 0.9 && currentScore / HighestScore <= 0.95)
            {
                Rank = "S";
            }
            else if (currentScore / HighestScore > 0.95 && currentScore / HighestScore <1)
            {
                Rank = "SS";
            }
            else if (currentScore / HighestScore == 1)
            {
                Rank = "SSS";
            }

        }
       

        RankText.text = Rank;
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
        var floatingText = Instantiate(FloatingTextPrefab);
        floatingText.transform.position = _sender.transform.position+ new  Vector3(0,offset,0);
        floatingText.GetComponent<TextMesh>().text = floatingScore.ToString();
        //Instantiate(FloatingTextPrefab, _sender.transform.position,transform.rotation);
         floatingText.gameObject.transform.forward=floatingText.transform.position-target.transform.position;
    }

}
