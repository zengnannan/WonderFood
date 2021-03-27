using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : AIBase
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isHit != true)
        {
            var pool = FindObjectOfType<ObjectPooler>().nameToPool[transform.parent.name];
            ScoreManager.instance.ReduceScore(Random.Range(pool.minScore,pool.maxScore+1));
        }
        base.OnCollisionEnter(collision);

    }

}
