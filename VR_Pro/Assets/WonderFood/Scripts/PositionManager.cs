using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static PositionManager instance;
    public Transform[] targetPointPositions;
    public Transform[] InitialPointPositions;

    void Awake()
    {
        instance = this;
    }

    public Transform GetRandomPosition(Transform[] transforms)
    {
        var randomTarget = transforms[Random.Range(0, transforms.Length)];
        return randomTarget;
        
    }
}
