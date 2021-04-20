using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    [SerializeField] private float ClickDuration;
    private Vector3 lowest;
    private Vector3 highest;
    [SerializeField] private float fallDownDistance;

    private bool doOnce;
    private bool doOnce1;

    private void Awake()
    {
        doOnce = false;
        doOnce1 = false;
        highest = transform.position;
        lowest = transform.position - new Vector3(0f, fallDownDistance, 0f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (doOnce1 == false)
        {
            doOnce1 = true;
           SoundManager.instance.PlaySound("叮 铃声"); 
        }
        
    }
    private void OnTriggerStay(Collider collider)
    {Debug.Log("I'm in Button");
        if (!collider.CompareTag("Button"))
        {
            Debug.Log(collider.name);
            transform.DOMove(lowest, ClickDuration);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Button"))
        {
            transform.DOMove(highest, ClickDuration);
            if (collider.GetComponent<WangZi>() != null || collider.GetComponent<Pan>() != null)
            {
                if (!UITimer.instance.GameStart && SceneManager.GetActiveScene().buildIndex != 1)
                {
                    if (doOnce == false)
                    {
                        doOnce = true;
                        ReadyGO.instance.StartButton();
                    }
                    
                }
            }
        }
    }

}
