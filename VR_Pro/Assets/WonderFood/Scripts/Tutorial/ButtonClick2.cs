using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ButtonClick2 : XRBaseInteractable
{
    [SerializeField] private float speed;
    private GameObject Switch;
    private Vector3 lowest;
    private Vector3 highest;
    private NewTutorial tutorial;
    private bool doOnce;
    private bool playOnce;
    private TutorialSound tutorialSound;

    protected override void Awake()
    {
        doOnce = false;
        playOnce = false;
        base.Awake();
        onHoverEntered.AddListener(StartPress);
        onHoverExited.AddListener(EndPress);
        tutorial = FindObjectOfType<NewTutorial>();
        tutorialSound = FindObjectOfType<TutorialSound>();
    }


    private void OnDestroy()
    {
        onHoverEntered.RemoveListener(StartPress);
        onHoverExited.RemoveListener(EndPress);
    }

    public void EndPress(XRBaseInteractor arg0)
    {
        Switch.transform.DOMove(highest, speed);

    }

    public void StartPress(XRBaseInteractor arg0)
    {
        Debug.Log("StartPress:"+arg0.name);
        Switch.transform.DOMove(lowest, speed);
    }
    public void testMethod()
    {
        Debug.Log("StartPress:");
    }

    private void Start()
    {
        Switch = gameObject;

        highest = Switch.transform.position;
        lowest = Switch.transform.position - new Vector3(0f, 0.03f, 0f);
    }

    // private void OnTriggerStay(Collider collider)
    // {
    //     Switch.transform.DOMove(lowest, speed);
    //
    // }
    //
    // private void OnTriggerExit(Collider collider)
    // {
    //     Switch.transform.DOMove(highest, speed);
    // }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Button"))
        {
            Switch.transform.DOMove(highest, speed);
            if (collider.GetComponent<WangZi>() != null || collider.GetComponent<Pan>() != null)
            {
                if (tutorial.ready == true)
                {
                   SoundManager.instance.PlaySound("叮 铃声");
                }

            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (!collider.CompareTag("Button"))
        {
            Debug.Log(collider.name);
            Switch.transform.DOMove(lowest, speed);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Button"))
        {
            Switch.transform.DOMove(highest, speed);
            if (playOnce==false&&tutorial.ready==false&&tutorial.finishedTenVoice==true)
            {
                tutorialSound.PlaySound(11,PlayOnceFalse);
                playOnce = true;
            }

            if (collider.GetComponent<WangZi>()!=null||collider.GetComponent<Pan>()!=null)
            {
                if (tutorial.ready==true)
                {
                    SceneManager.LoadScene(2);
                }

            }
        }
    }

    private void PlayOnceFalse()
    {
        playOnce = false;
    }
}
