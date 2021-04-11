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

    public float shootInterval1;
    public float shootInterval2;
    public float shootInterval3;

    private float lastShootTime;

    private Vector3 shootPosition;
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
            BoardShoot();
        }
    }

    public GameObject Shoot()
    {
        //First Get a Pool according to its chance
        var randomPool = Probability.GetChancePool<Pool>(objectPooler.pools);
        //Randomly Pick a Prefab in the pool
        var randomAI = objectPooler.GetGameObject(randomPool.name);

        randomAI.transform.position = shootPosition;

        return randomAI;
    }

    public void BoardShoot()
    {
        var randomPosition = PositionManager.instance.GetRandomPosition(PositionManager.instance.InitialPointPositions);
        shootPosition = randomPosition.position;

        var board = randomPosition.GetChild(0).gameObject;
        board.SetActive(true);
        var anim = board.GetComponent<Animator>();
        anim.SetTrigger("Shoot");
    }

}
