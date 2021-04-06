using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : AIBase
{
    private event Action stateTime;

    

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isHit != true && isGrounded != true)
        {
            isGrounded = true;
            var pool = FindObjectOfType<ObjectPooler>().nameToPool[transform.parent.name];
            ScoreManager.instance.ReduceScore(UnityEngine.Random.Range(pool.minScore,pool.maxScore+1));
        }
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            StartCoroutine(ResetTheGameobject());
        }
        if (collision.gameObject.CompareTag("Pan"))
        {
            SoundManager.instance.PlaySound("HitEnemy");
            StartCoroutine(HitPan());


        }

    }

}


