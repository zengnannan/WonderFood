using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

public class ButtonClick : XRBaseInteractable
{
    public UnityEvent onPress = null;
    private GameObject Switch;
    [SerializeField] private float speed;

    private bool isClick;
    private bool hold;
    private Vector3 lowest;
    private Vector3 highest;

    private float yMin = 0f;
    private float yMax = 0f;
    private bool previousPress = false;

    private float previousHandHeight = 0.0f;
    private XRBaseInteractor hoverInteractor = null;
    protected override void Awake()
    {
        base.Awake();
        onHoverEntered.AddListener(StartPress);
        onHoverExited.AddListener(EndPress);
    }

    public void EndPress(XRBaseInteractor arg0)
    {
        hoverInteractor = null;
        previousHandHeight = 0f;

        previousPress = false;
        SetYPosition(yMax);
    }

    public void StartPress(XRBaseInteractor arg0)
    {
        Debug.Log("I'M ENTER!!");
        hoverInteractor = arg0;
        previousHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
    }

    private void OnDestroy()
    {
        onHoverEntered.RemoveListener(StartPress);
        onHoverExited.RemoveListener(EndPress);
    }
    private void Start()
    {
        Switch = gameObject;
        //isClick = false;

        highest = Switch.transform.position;
        lowest = Switch.transform.position - new Vector3(0f, 0.03f, 0f);

        SetMinMax();
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        yMax = transform.localPosition.y;
        yMin = transform.localPosition.y - (float)(collider.bounds.size.y * 0.001);
        Debug.Log(yMin);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        
        if (hoverInteractor != null)
        {Debug.Log("eNTER LALAL");
            float newHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPosition(newPosition);
            Debug.Log("Handdifference is"+handDifference);
            CheckPress();
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);
        return localPosition.y;

    }

    private void SetYPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(position, yMin, yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        if (inPosition && inPosition != previousPress)
        {
            onPress.Invoke();
        }

        previousPress = inPosition;
    }

    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + 0.01f);
        return transform.localPosition.y == inRange;
    }
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.name);
        Switch.transform.DOMove(lowest, speed);
    }

    private void OnTriggerExit(Collider collider)
    {
        Switch.transform.DOMove(highest, speed);
    }

}
