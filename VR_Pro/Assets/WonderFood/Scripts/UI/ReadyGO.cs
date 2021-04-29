using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyGO : MonoBehaviour
{
    private Animator anim;
    public static ReadyGO instance;
    void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
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
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        anim.SetTrigger("Ready");
    }
 

    void GameTimeStart()
    {
        UITimer.instance.GameStart = true;
        Destroy(gameObject);
    }

    void ReadyAudio()
    {
        SoundManager.instance.PlaySound("Voice_Ready");
    }

    void GoAudio()
    {
        SoundManager.instance.PlaySound("Voice_GO");
    }
}
