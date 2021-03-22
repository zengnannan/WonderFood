using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Transform target;
    public bool isLaunch;

    public float h = 25;
    public float gravity = -18;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("VR Rig").transform;
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
            Debug.Log(this.transform.position);
            Launch();
        }        
    }
    void Launch()
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

    void GoBakToPool()
    {
        isLaunch = false;     
        this.transform.position = GetComponentInParent<Transform>().position;       
        GetComponent<PooledObject>().pool.ReturnObject(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GoBakToPool();
        }
    }


}
