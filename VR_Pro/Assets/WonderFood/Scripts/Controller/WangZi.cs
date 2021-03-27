using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangZi : ControllerBase
{
    void OnTriggerEnter(Collider collider)
    {
        var objType = GetAIType(collider.gameObject);
        var objScore = GetAIScore(collider.gameObject);
        

        if (objType == AIType.WantedAI && collider.gameObject.GetComponent<AIBase>().isHit != true)
        {
            collider.gameObject.GetComponent<AIBase>().isHit = true;
            ScoreManager.instance.AddScore(objScore);
        }

        if (collider.GetComponent<EnemyAI>()!= null)
        {
            if (collider.GetComponent<EnemyAI>().isHit == false)
            {
                collider.GetComponent<EnemyAI>().isHit = true;
                ScoreManager.instance.ReduceScore(objScore);
            }
            
        }
    }
}
