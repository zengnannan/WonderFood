using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VelocityComponent : MonoBehaviour
{
    public static Vector3 AverageVelocity;
    public float Multiplier;
    public int Dampening;
    private List<Vector3> velocityVectors = new List<Vector3>();
    private Vector3 previousPosition;

    void Awake()
    {
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (velocityVectors.Count >= Dampening)
        {
            velocityVectors.RemoveAt(0);
        }

        var velocityVector = transform.position - previousPosition;

        velocityVectors.Add(velocityVector);

        var averageVelocity = Vector3.zero;

        foreach(var v in velocityVectors)
        {
            averageVelocity += v;
        }

        averageVelocity = averageVelocity / velocityVectors.Count;

        previousPosition = transform.position;
        AverageVelocity = averageVelocity * Multiplier;
        Debug.Log(averageVelocity);
    }
}
