using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public static UITimer instance;
    public float maxTime;
    public float currentTime;
    [SerializeField] private Text timeDisplay;

    public bool isGameOver;
    public bool GameStart;

    public int Min;
    public int Sec;

    private void Awake()
    {
        instance = this;
        this.gameObject.SetActive(true);
        isGameOver = false;
        GameStart = false;
        currentTime = maxTime;
        
    }


    private void Update()
    {
        Min = (int)currentTime / 60;
        Sec = (int) currentTime % 60;

        timeDisplay.text = string.Format("{0:D2}", Min)+":"+ string.Format("{0:D2}", Sec);

        if (!isGameOver && GameStart)
        {
            currentTime -= Time.deltaTime;
            
        }

        if (currentTime <= 5)
        {
            timeDisplay.color = new Vector4(200, 0, 0, 255);
        }

        if (currentTime <= 0)
        {
            isGameOver = true;
            currentTime = 0;
        }
    }

    public void ResetTime()
    {
        currentTime = maxTime;
    }
}
