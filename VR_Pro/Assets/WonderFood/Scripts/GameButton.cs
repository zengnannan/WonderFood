using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameButton : MonoBehaviour
{
    [SerializeField] private float ClickDuration;
    private Vector3 lowest;
    private Vector3 highest;
    [SerializeField] private float fallDownDistance;

    private void Awake()
    {
        highest = transform.position;
        lowest = transform.position - new Vector3(0f, fallDownDistance, 0f);
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
                if (!UITimer.instance.GameStart)
                {
                    ReadyGO.instance.StartButton();
                }
                   
                
            }
        }
    }

}
