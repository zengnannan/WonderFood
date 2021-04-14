using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private ObjectPooler objectPooler;
    private Launcher launcher;
    private UITimer uiTimer;

    public float time1;
    public float time2;
    public float time3;

    public float nowTime;

    void Awake()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
        launcher = FindObjectOfType<Launcher>();
        uiTimer = FindObjectOfType<UITimer>();
    }

    void Update()
    {
        nowTime = uiTimer.maxTime - uiTimer.currentTime;

        if (nowTime<=time1)
        {
            //Phase1
            foreach (var pool in objectPooler.pools)
            {
                pool.chance = pool.chance1;
            }

            launcher.shootInterval = launcher.shootInterval1;
        }
        else if (nowTime<=time2)
        {
            //Phase2
            foreach (var pool in objectPooler.pools)
            {
                pool.chance = pool.chance2;
            }

            launcher.shootInterval = launcher.shootInterval2;
        }
        else if (nowTime<=time3)
        {
            //Phase3
            foreach (var pool in objectPooler.pools)
            {
                pool.chance = pool.chance3;
            }

            launcher.shootInterval = launcher.shootInterval3;
        }
    }

}
