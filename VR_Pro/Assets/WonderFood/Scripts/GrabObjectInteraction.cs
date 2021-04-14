using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabObjectInteraction : MonoBehaviour
{
    private XRBaseInteractor interactor;
    private XRGrabInteractable grabInteractor;
    public bool hasPickedUp;
    public bool hasPickWangzi;
    public bool hasPickPan;

    private void Awake()
    {
        hasPickedUp = false;
        hasPickWangzi = false;
        hasPickPan = false;
    }

    public void HoverOver()
    {
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    private void OnEnable()
    {
        grabInteractor = GetComponent<XRGrabInteractable>();
        
    }

    private void OnDisable()
    {

    }

    public void GrabEnd()
    {
        // interactor.GetComponent<XRBaseController>().modelPrefab.gameObject.SetActive(true);
        //HandModelVisibility(false);
        //interactor.transform.GetChild(0).gameObject.SetActive(true);
        interactor.transform.GetChild(0).gameObject.SetActive(true);
        hasPickedUp = false;
        if (GetComponent<WangZi>() != null)
        {
            if (interactor.name == "LeftHand Controller")
            {
                hasPickWangzi = false;
            }
        }
        if (GetComponent<Pan>() != null)
        {
            if (interactor.name == "RightHand Controller")
            {
                hasPickPan = false;
            }
        }
    }

    public  void GrabbedBy()
    {
        interactor = GetComponent<XRGrabInteractable>().selectingInteractor;
        Debug.Log(interactor.name);
        interactor.transform.GetChild(0).gameObject.SetActive(false);
        hasPickedUp = true;
        //HandModelVisibility(true);
        if (GetComponent<WangZi>()!=null)
        {
            if (interactor.name=="LeftHand Controller")
            {
                hasPickWangzi = true;
            }
        }
        if (GetComponent<Pan>() != null)
        {
            if (interactor.name == "RightHand Controller")
            {
                hasPickPan = true;
            }
        }
    }


    public void HoverEnd()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
}
