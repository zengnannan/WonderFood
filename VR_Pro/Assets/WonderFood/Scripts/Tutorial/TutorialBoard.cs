using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialBoard : MonoBehaviour
{
    private Vector3 lowest;
    private Vector3 highest;
    [SerializeField] private float goingDownDistance;

    public float duration;

    private void Start()
    {
        highest = transform.position;
        lowest = transform.position - new Vector3(0, goingDownDistance, 0);
    }

    private void Update()
    {
        Debug.Log("highest:"+highest+"lowest"+lowest);
    }
    public void GoingUp()
    {
        this.transform.DOMove(highest, duration);
    }

    public void GoingDown()
    {
        this.transform.DOMove(lowest, duration);
    }
}
