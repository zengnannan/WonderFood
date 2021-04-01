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

    private void Awake()
    {
        instance = this;
        this.gameObject.SetActive(true);
        isGameOver = false;


        timeDisplay.text = maxTime.ToString();
    }

    private void Start()
    {
        currentTime = maxTime;
    }



    private void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            timeDisplay.text = ((int)currentTime).ToString();
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
