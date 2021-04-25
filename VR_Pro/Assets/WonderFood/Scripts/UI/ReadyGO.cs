using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyGO : MonoBehaviour
{
    [SerializeField] private Text ReadyGoText;
    private Animator anim;
    public static ReadyGO instance;
    void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        gameObject.GetComponent<Text>().enabled = false;
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("TutorialEnter")==1)
        {
            StartButton();
        }
    }

    public void StartButton()
    {
        gameObject.GetComponent<Text>().enabled = true;
        anim.SetTrigger("Ready");
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
