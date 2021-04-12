using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonClickTrigger : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject Switch;
    private Vector3 lowest;
    private Vector3 highest;
    // Start is called before the first frame update
    private void Start()
    {
        Switch = transform.GetChild(1).gameObject;

        highest = Switch.transform.position;
        lowest = Switch.transform.position - new Vector3(0f, 0.03f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.transform.GetComponentInParent<ButtonClickTrigger>() == null)
        {
            Debug.Log("Nat come in!!");
        Switch.transform.DOMove(lowest, speed);
        }
        
    
    }
    
    private void OnTriggerExit(Collider collider)
    {
        Switch.transform.DOMove(highest, speed);
    }
}
