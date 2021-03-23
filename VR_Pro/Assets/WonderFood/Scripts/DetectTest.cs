using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTest : MonoBehaviour
{
    public Rigidbody rb;
    public List<GameObject> detectedList;
    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {

    }

    //void DetectThing()
   // {
     //   Collider2D[] hitThings = Physics2D.OverlapCircleAll(attackPoint.position, DetectRange, thinglayers);
        //Debug.Log(hitEnemies.Length);
      //  if (hitThings.Length > 0)
      //  {
       //     for (int i = 0; i < hitThings.Length; i++)
        //    {
          //      float dis = Vector3.Distance(hitThings[i].gameObject.transform.position, playerTrans.position);
          //      thingDic.Add(dis, hitThings[i].gameObject);
                //Debug.Log(dis);
           //     if (!thingList.Contains(dis))
           //     {
           //         thingList.Add(dis);
           //     }
          //  }
      //  }
   // }
}
