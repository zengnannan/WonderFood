using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabObjectInteraction : MonoBehaviour
{
    private XRBaseInteractor interactor;
    private XRGrabInteractable grabInteractor;

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
    }

    public  void GrabbedBy()
    {
        interactor = GetComponent<XRGrabInteractable>().selectingInteractor;
        Debug.Log(interactor.name);
        interactor.transform.GetChild(0).gameObject.SetActive(false);

        //HandModelVisibility(true);
    }


    public void HoverEnd()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
}
