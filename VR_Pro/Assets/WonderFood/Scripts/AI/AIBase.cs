using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBase : MonoBehaviour
{
    private Rigidbody rb;
    private Transform target;
    private bool isLaunch;
    private PositionManager positionManager;

    [Header("Fly Attributes")]
    public float h = 20;
    public float gravity = -10;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        positionManager = PositionManager.instance;
        target = positionManager.GetRandomPosition(positionManager.targetPointPositions);
    }

    void Start() 
    {
        isLaunch = false;
        rb.useGravity = false;
    }

    void Update()
    {
        if (isLaunch == false)
        {            
            AutoLaunch();
        }
    }

    void AutoLaunch()
    {
        rb.useGravity = true;
        Physics.gravity = Vector3.up * gravity;
        rb.velocity = CalculateLaunchVelocity();
        isLaunch = true;
    }

    Vector3 CalculateLaunchVelocity()
    {

        float displaymentY = target.position.y - transform.position.y;
        Vector3 displaymentXZ = new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displaymentXZ / (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displaymentY - h) / gravity));

        return velocityXZ + velocityY;
    }

    void Reset()
    {
        isLaunch = false;
        GetComponent<isPooledObject>().pooler.ReturnObject(this.gameObject);
        target = positionManager.GetRandomPosition(positionManager.targetPointPositions);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            
            Reset();
        }
        if (collision.gameObject.CompareTag("Pan"))
        {
            rb.velocity = VelocityComponent.AverageVelocity;
        }
    }


}
