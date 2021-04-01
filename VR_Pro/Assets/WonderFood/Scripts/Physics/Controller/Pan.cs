using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : ControllerBase
{
   void OnTriggerEnter(Collider collider)
   {
        var objType = GetAIType(collider.gameObject);
        var objScore = GetAIScore(collider.gameObject);

        if (objType == AIType.EnemyAI)
        {
            if (collider.GetComponent<EnemyAI>().isHit == false && collider.GetComponent<EnemyAI>().isGrounded == false)
            {
               collider.GetComponent<EnemyAI>().isHit = true;
               ScoreManager.instance.AddScore(objScore);
            }
           
        }
   }
}
