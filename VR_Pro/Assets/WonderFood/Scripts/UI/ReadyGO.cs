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
    }

    void StartGo()
    {
        ReadyGoText.text = "Go";
        ReadyGoText.color = Color.green;
    }

    void GameTimeStart()
    {
        UITimer.instance.GameStart = true;
        Destroy(gameObject);
    }
}
