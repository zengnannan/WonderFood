using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatingButton : MonoBehaviour
{
    public float RotatingSpeed;
    public float ChangedScale;
    public float IdleScale;
    public float scaleUPSpeed;
    public float scaleDOWNSpeed;
    private bool needGoDown;

    protected bool doOnce;

    protected void Awake()
    {
        needGoDown = false;
    }

    protected void Start()
    {
        doOnce = true;
    }
    protected virtual void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotatingSpeed);
        if (needGoDown)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(IdleScale, IdleScale, IdleScale),
            scaleDOWNSpeed * Time.deltaTime);
        }
    }

    protected virtual void OnTriggerStay(Collider col)
    {
        if (col.GetComponent<WangZi>() != null || col.GetComponent<Pan>() != null)
        {
            needGoDown = false;
           transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(ChangedScale,ChangedScale,ChangedScale), scaleUPSpeed * Time.deltaTime); 
        }
        
    }

    protected virtual void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<WangZi>() != null || col.GetComponent<Pan>() != null && needGoDown == false)
        {
            needGoDown = true;
        }
        
    }

}
