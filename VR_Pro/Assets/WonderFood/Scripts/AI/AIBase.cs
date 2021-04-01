using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBase : MonoBehaviour
{
    private Rigidbody rb;
    private Transform target;
    private bool isLaunch;
    private PositionManager positionManager;

    public bool isHit;
    public bool isGrounded;

    [Header("Fly Attributes")]
    public float h = 20;
    public float gravity = -10;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        positionManager = PositionManager.instance;
        target = positionManager.GetRandomPosition(positionManager.targetPointPositions);
    }

    void Start() 
    {
        isLaunch = false;
        isHit = false;
        isGrounded = false;
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

    protected virtual void Reset()
    {
        isLaunch = false;
        isHit = false;
        isGrounded = false;
        GetComponent<isPooledObject>().pooler.ReturnObject(this.gameObject);
        target = positionManager.GetRandomPosition(positionManager.targetPointPositions);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            StartCoroutine(ResetTheGameobject());
        }
        if (collision.gameObject.CompareTag("Pan"))
        {
            SoundManager.instance.PlaySound("HitFruit");
            StartCoroutine(HitPan());
        }
    }

    protected IEnumerator ResetTheGameobject()
    {
        yield return new WaitForSeconds(2f);
        Reset();
    }

    protected IEnumerator HitPan()
    {
        yield return new WaitForSeconds(0.01f);
        rb.velocity = VelocityComponent.AverageVelocity;
    }

}
