using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public static BallLauncher instance;

    public ObjectPool ballPool;
    public int ballNum;
    public Transform bornPlace;

    public float shootInternal;
    public float lastShootTime;

    private void Awake()
    {
        ballPool = GetComponent<ObjectPool>();
    }
    void Start()
    {
        //ballList = new List<GameObject>();
        //for (int i = 0; i < ballNum; i++)
        //{
          //  var ball = CreateBall(bornPlace);
            //ball.SetActive(false);
        //}
    }

    void Update()
    {
        if (Time.time >= lastShootTime + shootInternal)
        {
            lastShootTime = Time.time;
            CreateBall(bornPlace);
        }
    }



    public GameObject CreateBall(Transform bornPlace)
    {
        var ball = ballPool.GetObject();
        ball.transform.position = new Vector3(bornPlace.position.x, bornPlace.position.y, bornPlace.position.z);
        return ball;
    }


}
