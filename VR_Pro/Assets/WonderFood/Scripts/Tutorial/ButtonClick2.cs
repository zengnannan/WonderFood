using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class ButtonClick2 : XRBaseInteractable
{
    [SerializeField] private float speed;
    private GameObject Switch;
    private Vector3 lowest;
    private Vector3 highest;

    protected override void Awake()
    {
        base.Awake();
        onHoverEntered.AddListener(StartPress);
        onHoverExited.AddListener(EndPress);
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
        }
    }
}
