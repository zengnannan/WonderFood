using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyGO : MonoBehaviour
{
    [SerializeField] private Text ReadyGoText;
    private Animator anim;

    void Start()
    {
        Time.timeScale = 0;
        Destroy(gameObject,3);
    }

    void StartGo()
    {
        ReadyGoText.text = "Go";
        ReadyGoText.color = Color.green;
    }

    void GameTimeStart()
    {
        Time.timeScale = 1;
    }
}
