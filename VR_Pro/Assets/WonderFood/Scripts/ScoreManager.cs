using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int totalScore;
    private ObjectPooler objectPooler;

    void Awake()
    {
        instance = this;
        totalScore = 0;
        objectPooler = FindObjectOfType<ObjectPooler>();
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
