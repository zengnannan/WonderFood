using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Pool
{
    [Header("AI Information")]
    public string name;

    public AIType aIType;
    public GameObject prefab;
    public int size;

    [Header("Probability")]
    public int chance;
    [HideInInspector] public int minChance;
    [HideInInspector] public int maxChance;

    [Header("Score")]
    public int minScore;
    public int maxScore;

   
}
 public enum AIType
    {
        EnemyAI,
        NoNeedAI,
        WantedAI
    }
public class ObjectPooler : MonoBehaviour
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> nameToQueue;
    public Dictionary<string, Pool> nameToPool;

    // Start is called before the first frame update
    void Start()
    {
        nameToQueue = new Dictionary<string, Queue<GameObject>>();
        nameToPool = new Dictionary<string, Pool>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            GameObject poolName = new GameObject(pool.name);
            poolName.transform.SetParent(this.transform);
            
            nameToQueue.Add(pool.name, objectPool);
            nameToPool.Add(pool.name, pool);

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = CreateInstance(pool.name);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }
    }

    public GameObject GetGameObject(string name)
    {
        var pool = nameToQueue[name];
        var obj = pool.Count > 0 ? pool.Dequeue() : CreateInstance(name);
        obj.SetActive(true);
        return obj;
    }

    public void Reset()
    {
        var objectsToReturn = new List<GameObject>();
        foreach (var instance in transform.GetComponentsInChildren<isPooledObject>())
        {
            if (instance.gameObject.activeSelf)
            {
                objectsToReturn.Add(instance.gameObject);
            }
        }
        foreach (var instance in objectsToReturn)
        {
            ReturnObject(instance);
        }
    }

    public void ReturnObject(GameObject obj)
    {
        var objPoolQueue = nameToQueue[obj.transform.parent.name];
        obj.SetActive(false);
        objPoolQueue.Enqueue(obj);
    }

    private GameObject CreateInstance(string name)
    {
        var pool = nameToPool[name];
        var obj = Instantiate(pool.prefab);
        var pooledObject = obj.AddComponent<isPooledObject>();        
        pooledObject.pooler = this;
        Transform namePool = GameObject.Find(pool.name).transform;
        obj.transform.SetParent(namePool);
        return obj;
    }
}

public class isPooledObject : MonoBehaviour
{
    public ObjectPooler pooler;
}
