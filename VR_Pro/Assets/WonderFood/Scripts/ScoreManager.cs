using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int totalScore;
    private ObjectPooler objectPooler;
    public Text scoreText;


    void Awake()
    {
        instance = this;
        totalScore = 0;
        objectPooler = FindObjectOfType<ObjectPooler>();
    }

    void Update()
    {
        if (totalScore < 0)
        {
            totalScore = 0;
        }
        scoreText.text=totalScore.ToString();
    }
    public void AddScore(int score)
    {
        totalScore += score;
    }
    public void ReduceScore(int score)
    {
        totalScore -= score;
    }

}
