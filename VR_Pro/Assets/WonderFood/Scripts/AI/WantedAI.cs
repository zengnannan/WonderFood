using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedAI : AIBase
{
    protected override void Start()
    {
        base.Start();
        aiEventArgs.correctSFX = "CollectDing";
        aiEventArgs.wrongSFX = "MissHit";
    }

    protected override void AutoLaunch()
    {
        base.AutoLaunch();
        OnStateTrue += UIObjectNum.instance.AddObjectiveNum;
    }

    protected override void Reset()
    {
        base.Reset();
        OnStateTrue -= UIObjectNum.instance.AddObjectiveNum;
    }

    protected void OnTriggerEnter(Collider collision)
    {
       
        //玩家对WantedAI【错误】情况：掉到地上时，没有被击中过，也没有被掉到地上过
        if (collision.gameObject.CompareTag("Ground") && isHit != true && isGrounded != true)
        {
            isGrounded = true;
            StateFalse(aiEventArgs);
        }
        //玩家对WantedAI【正确】情况：击中Wang
        if (collision.gameObject.CompareTag("Wang") && isHit != true && isGrounded != true)
        { 
            isHit = true;
            StateTrue(aiEventArgs);
            //StartCoroutine(HitPan());
        }

        if (collision.gameObject.CompareTag("Pan"))
        {
            SoundManager.instance.PlaySound("HitFruit");
            if (isHit!=true&&isGrounded!=true)
            {
                isHit = true;
                StateFalse(aiEventArgs);
            }
        }
    }
}
