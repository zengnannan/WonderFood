using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangZi : ControllerBase
{
    private UIObjectNum uiObjectNum;
    protected override void Start()
    {
        base.Start();
        uiObjectNum = FindObjectOfType<UIObjectNum>();
    }

    void OnTriggerEnter(Collider collider)
    {
        var objType = GetAIType(collider.gameObject);
        var objScore = GetAIScore(collider.gameObject);
        

        if (objType == AIType.WantedAI && collider.gameObject.GetComponent<AIBase>().isHit != true && collider.gameObject.GetComponent<AIBase>().isGrounded != true)
        {
            for (int i = 0; i <uiObjectNum.currentObjectNum.Length ; i++)
            {
                if (collider.transform.parent.name == uiObjectNum.ObjectName[i])
                {
                    uiObjectNum.currentObjectNum[i]++;
                }
            }
            SoundManager.instance.PlaySound("CollectDing");
            collider.gameObject.GetComponent<AIBase>().isHit = true;
            ScoreManager.instance.AddScore(objScore);
        }

        if (collider.GetComponent<EnemyAI>()!= null)
        {
            if (collider.GetComponent<EnemyAI>().isHit == false && collider.GetComponent<EnemyAI>().isGrounded == false)
            {
                collider.GetComponent<EnemyAI>().isHit = true;
                ScoreManager.instance.ReduceScore(objScore);
            }
            
        }
    }
}
