using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore;
    public int lastScore;
    public Text scoreText;


    void Awake()
    {
        instance = this;
        currentScore = 0;
        lastScore = 0;
    }

    void Update()
    {
        if (currentScore < 0)
        {
            currentScore = 0;
        }
        scoreText.text=currentScore.ToString();
    }
    public void AddScore(object _sender, EventArgs _e)
    {
       GameObject ai = _sender as GameObject;
       AIEventArgs e = _e as AIEventArgs;
       lastScore = currentScore;
        currentScore +=(int) UnityEngine.Random.Range(e.pool.minScore * ComboSystem.instance.comboRatio, (e.pool.maxScore + 1) * ComboSystem.instance.comboRatio);

    }


}
