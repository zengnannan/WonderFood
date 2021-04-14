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
        if (UITimer.instance.GameStart && (!UITimer.instance.isGameOver))
        {
            if (Time.time >= lastShootTime + shootInterval)
            {
                lastShootTime = Time.time;
                BoardShoot();
            }
        }
    }

    public GameObject Shoot()
    {
        //First Get a Pool according to its chance
        var randomPool = Probability.GetChancePool<Pool>(objectPooler.pools);
        if (randomPool.aIType ==AIType.WantedAI || randomPool.aIType == AIType.EnemyAI)
        {
            var aiScore = (int)UnityEngine.Random.Range(randomPool.minScore * ComboSystem.instance.comboRatio,
           (randomPool.maxChance + 1) * ComboSystem.instance.comboRatio);
            ScoreManager.HighestScore += aiScore;
        }

        //Randomly Pick a Prefab in the pool
        var randomAI = objectPooler.GetGameObject(randomPool.name);

        randomAI.transform.position = shootPosition;

        return randomAI;
    }

    public void BoardShoot()
    {
        var randomPosition = PositionManager.instance.GetRandomPosition(PositionManager.instance.InitialPointPositions);
        shootPosition = randomPosition.position;

        var board = randomPosition.gameObject.transform.parent.gameObject;
        var anim = board.GetComponent<Animator>();
        anim.SetTrigger("Shoot");
    }

}
