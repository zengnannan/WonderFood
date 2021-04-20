using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingButton : MonoBehaviour
{
    public float RotatingSpeed;

    protected virtual void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotatingSpeed);
    }
}
