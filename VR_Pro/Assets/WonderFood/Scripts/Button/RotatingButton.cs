using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatingButton : MonoBehaviour
{
    public float RotatingSpeed;
    public float ChangedScale;
    public float IdleScale;
    public float scaleSpeed;

    protected virtual void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotatingSpeed);
    }

    protected virtual void OnTriggerStay()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(ChangedScale,ChangedScale,ChangedScale), scaleSpeed * Time.deltaTime);
    }

}
