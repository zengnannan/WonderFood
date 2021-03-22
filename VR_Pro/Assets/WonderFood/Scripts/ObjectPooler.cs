using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Pool
{
    [Header("AI Information")]
    public string tag;
    public GameObject prefab;
    public int size;

    [Header("Probability")]
    public int chance;
    [HideInInspector] public int minChance;
    [HideInInspector] public int maxChance;

}

public class ObjectPooler : MonoBehaviour
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> tagToQueue;
    public Dictionary<string, Pool> tagToPool;

    // Start is called before the first frame update
    void Start()
    {
        tagToQueue = new Dictionary<string, Queue<GameObject>>();
        tagToPool = new Dictionary<string, Pool>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            tagToQueue.Add(pool.tag, objectPool);
            tagToPool.Add(pool.tag, pool);

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = CreateInstance(pool.tag);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }
    }

    public GameObject GetGameObject(string tag)
    {
        var pool = tagToQueue[tag];
        var obj = pool.Count > 0 ? pool.Dequeue() : CreateInstance(tag);
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
        var objPoolQueue = tagToQueue[obj.tag];
        obj.SetActive(false);
        objPoolQueue.Enqueue(obj);
    }

    private GameObject CreateInstance(string tag)
    {
        var pool = tagToPool[tag];
        var obj = Instantiate(pool.prefab);
        var pooledObject = obj.AddComponent<isPooledObject>();        
        pooledObject.pooler = this;
        obj.tag = pool.tag;
        obj.transform.SetParent(transform);
        return obj;
    }
}

public class isPooledObject : MonoBehaviour
{
    public ObjectPooler pooler;
}
