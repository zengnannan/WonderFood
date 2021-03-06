using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool doOnce1;
    private bool doOnce2;
    private bool doOnce3;
    private bool doOnce4;


    private void Awake()
    {
        objectPooler = GetComponent<ObjectPooler>();
        instance = this;

        doOnce1 = true;
        doOnce2 = true;
        doOnce3 = true;
        doOnce4 = true;
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

        var nowTime = UITimer.instance.maxTime - UITimer.instance.currentTime;



        //First Get a Pool according to its chance
        var randomPool = Probability.GetChancePool<Pool>(objectPooler.pools);


        //Randomly Pick a Prefab in the pool
        var randomAI = objectPooler.GetGameObject(randomPool.name);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (nowTime > 0f && nowTime < 30f)
            {
                if (randomAI.gameObject.GetComponentInChildren<SpriteRenderer>() != null)
                {
                    randomAI.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
                }

                if (randomPool.name=="Apple" && doOnce1)
                {
                    SoundManager.instance.PlaySound("voice_Catch it");
                    doOnce1 = false;
                }
                else if(randomPool.name == "WaterMelon" && doOnce2)
                {
                    SoundManager.instance.PlaySound("voice_Catch it");
                    doOnce2 = false;
                }
                else if (randomPool.name == "Pear" && doOnce3)
                {
                    SoundManager.instance.PlaySound("voice_Hit it");
                    doOnce3 = false;
                }
                else if (randomPool.name == "TomatoEnemy"&& doOnce4)
                {
                    SoundManager.instance.PlaySound("voice_Hit it");
                    doOnce4 = false;
                }
            }
        }

        if (randomPool.aIType == AIType.WantedAI || randomPool.aIType == AIType.EnemyAI)
        {
            var aiScore = Random.Range(randomPool.minScore * ComboSystem.instance.comboRatio,
                (randomPool.maxScore + 1) * ComboSystem.instance.comboRatio);
            randomAI.gameObject.GetComponent<AIBase>().myScore = (int)aiScore;
            ScoreManager.HighestScore += randomAI.GetComponent<AIBase>().myScore;
        }
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
