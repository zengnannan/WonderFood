using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NoNeedAI : AIBase
{
    public GameObject WrongCatch;
    public float offset;
    private GameObject player;
    protected override void Start()
    {
        base.Start();
        aiEventArgs.wrongSFX = "MissHit";
        player = GameObject.Find("XR Rig");
    }

    protected override void AutoLaunch()
    {
        rb.useGravity = true;
        Physics.gravity = Vector3.up * gravity;
        rb.velocity = CalculateLaunchVelocity();
        isLaunch = true;

        Debug.Log("111");

        //玩家对AI【错误】反映的订阅：重置Combo数、错误音效
        OnStateFalse += ComboSystem.instance.ResetComboNum;
        OnStateFalse += SoundManager.instance.PlayWrongSFX;
    }

    protected override void Reset()
    {
        isLaunch = false;
        isHit = false;
        isGrounded = false;
        GetComponent<isPooledObject>().pooler.ReturnObject(this.gameObject);
        target = PositionManager.instance.GetRandomPosition(PositionManager.instance.targetPointPositions);
        //target = positionManager.GetRandomPosition(positionManager.targetPointPositions);

        //玩家对EnemyAI【错误】反映的取消订阅：重置Combo数、喷脸特效、错误音效
        OnStateFalse -= ComboSystem.instance.ResetComboNum;
        OnStateFalse -= SoundManager.instance.PlayWrongSFX;
    }

    protected void OnTriggerEnter(Collider collision)
    {
       
        if (collision.gameObject.CompareTag("Wang") && isHit != true && isGrounded != true)
        {
            Debug.Log("NoNeed in Wang");
            isHit = true;
            ShowX();
            StateFalse(aiEventArgs);
        }

        if (collision.gameObject.CompareTag("Pan"))
        {
            isHit = true;
            SoundManager.instance.PlaySound("HitFruit");
        }
    }

    private void ShowX()
    {
        var currentPrefab = Instantiate(WrongCatch);
        currentPrefab.transform.position = this.transform.position + new Vector3(0, offset, 0);
        currentPrefab.gameObject.transform.forward = currentPrefab.transform.position - player.transform.position;
    }
}
