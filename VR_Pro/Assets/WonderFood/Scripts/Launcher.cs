using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class Launcher is in charge of the function that it will spawn an object to shoot every seconds we set.
/// </summary>
public class Launcher : MonoBehaviour
{
    public static Launcher instance;

    private ObjectPooler objectPooler;

    public float shootInterval;
    public float lastShootTime;
    private void Awake()
    {
        objectPooler = GetComponent<ObjectPooler>();  
        instance = this;
    }

    void Update()
    {
        if (Time.time >= lastShootTime + shootInterval)
        {
            lastShootTime = Time.time;
            Shoot();
        }
    }

    private GameObject Shoot()
    {
        //First Get a Pool according to its chance
        var randomPool = Probability.GetChancePool<Pool>(objectPooler.pools);
        //Randomly Pick a Prefab in the pool
        var randomAI = objectPooler.GetGameObject(randomPool.tag);

        randomAI.transform.position = PositionManager.instance.GetRandomPosition(PositionManager.instance.InitialPointPositions).position;

        return randomAI;
    }

}
