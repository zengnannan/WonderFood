using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [HideInInspector]public int currentScore;
    private int lastScore;
    public Text scoreText;
    private int floatingScore;
    public GameObject FloatingTextPrefab;
    public GameObject target;
    public float offset;
    public static int HighestScore;
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
        scoreText.text=currentScore.ToString();
        Debug.Log("Highest score is" + HighestScore);
        if(currentScore/HighestScore<=0.7)
        {
            Rank = "C";
        }
        else if(currentScore / HighestScore >0.7 && currentScore / HighestScore <= 0.8)
        {
            Rank = "B";
        }
        else if (currentScore / HighestScore > 0.8 && currentScore / HighestScore <= 0.0)
        {
            Rank = "A";
        }
        else if (currentScore / HighestScore > 0.9 && currentScore / HighestScore <=1)
        {
            Rank = "S";
        }
    }
    public void AddScore(object _sender, EventArgs _e)
    {
       GameObject ai = _sender as GameObject;
       AIEventArgs e = _e as AIEventArgs;
       lastScore = currentScore;
       floatingScore = (int) UnityEngine.Random.Range(e.pool.minScore * ComboSystem.instance.comboRatio,
           (e.pool.maxScore + 1) * ComboSystem.instance.comboRatio);
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
