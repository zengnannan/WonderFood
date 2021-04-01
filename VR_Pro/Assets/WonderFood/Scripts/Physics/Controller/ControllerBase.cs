using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBase : MonoBehaviour
{
    private ObjectPooler objectPooler;
    void Awake()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
    }

    protected virtual void Start()
    {

    }

    protected AIType GetAIType(GameObject obj)
    {
        var poolName = obj.transform.parent.name;
        var pool = objectPooler.nameToPool[poolName];
        return pool.aIType;
    }

    protected int GetAIScore(GameObject obj)
    {
        var poolName = obj.transform.parent.name;
        var pool = objectPooler.nameToPool[poolName];
        var randomScore = Random.Range(pool.minScore, pool.maxScore+1);
        return randomScore;
    }
}
