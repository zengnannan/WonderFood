using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : AIBase
{
    public event EventHandler OnEnemyStateTrue;
    public event EventHandler OnEnemyStateFalse;
    


    protected override void Start()
    {
        base.Start();
        aiEventArgs.correctSFX = "HitEnemy";
        aiEventArgs.wrongSFX = "MissHit";
    }

    protected override void AutoLaunch()
    {
        base.AutoLaunch();
        OnStateFalse += SpitAtPlayer;
    }

    protected override void Reset()
    {
        base.Reset();
        
        OnStateFalse -= SpitAtPlayer;
    }

    protected void OnTriggerEnter(Collider collision)
    {
       
        //玩家对EnemyAI【错误】情况：掉到地上时，没有被击中过，也没有被掉到地上过
        if (collision.gameObject.CompareTag("Ground") && isHit != true && isGrounded != true)
        {
            isGrounded = true;
            base.StateFalse(aiEventArgs);
        }

        if (collision.gameObject.CompareTag("Wang") && isHit != true && isGrounded != true)
        {
            isHit = true;
            base.StateFalse(aiEventArgs);
        }

        //玩家对EnemyAI【正确】情况：击中Pan
        if (collision.gameObject.CompareTag("Pan"))
        {
            isHit = true;
            StateTrue(aiEventArgs);
        }
    }
    protected void SpitAtPlayer(object _sender, EventArgs _e)
    {
        GameObject ai = _sender as GameObject;
        AIEventArgs e = _e as AIEventArgs;
    }
}


