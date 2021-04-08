using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIBase : MonoBehaviour
{
    protected Rigidbody rb;
    protected Transform target;
    protected bool isLaunch;
    protected PositionManager positionManager;

    public bool isHit;
    public bool isGrounded;

    protected AIEventArgs aiEventArgs;

    [Header("Fly Attributes")]
    public float h = 20;
    public float gravity = -10;

    /// <summary>
    /// 2021/4/6 Every AI has 2 events, OnStateTrue and OnStateFalse.
    /// If player does the 【RIGHT】 operation to this AI, 【OnStateTrue】 will be called.
    /// If player does the 【Wrong】 operation to this AI, 【OnStateFalse】 will be called.
    /// </summary>
    protected event EventHandler OnStateTrue;
    protected event EventHandler OnStateFalse;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        positionManager = PositionManager.instance;
        target = positionManager.GetRandomPosition(positionManager.targetPointPositions);
    }

    protected virtual void Start()
    {
        isLaunch = false;
        isHit = false;
        isGrounded = false;
        rb.useGravity = false;
        
        //The basic data of every AI
        aiEventArgs = new AIEventArgs();
        aiEventArgs.poolName = this.transform.parent.name;
        aiEventArgs.pool = ObjectPooler.instance.nameToPool[aiEventArgs.poolName];
    }

    protected virtual void Update()
    {
        if (isLaunch == false)
        {
            AutoLaunch();
        }
    }

    protected virtual void AutoLaunch()
    {
        rb.useGravity = true;
        Physics.gravity = Vector3.up * gravity;
        rb.velocity = CalculateLaunchVelocity();
        isLaunch = true;
        //Subscribe【Right】event: AddScore、AddComboNum、PlayCorrectSFX
        OnStateTrue += ScoreManager.instance.AddScore;
        OnStateTrue += ComboSystem.instance.AddComboNum;
        OnStateTrue += SoundManager.instance.PlayCorrectSFX;

        //Subscribe 【Wrong】event: ResetComboNum、PlayWrongSFX
        OnStateFalse += ComboSystem.instance.ResetComboNum;
        OnStateFalse += SoundManager.instance.PlayWrongSFX;
    }

    protected Vector3 CalculateLaunchVelocity()
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

        // Unsubscribe【Right】event: AddScore、AddComboNum、PlayCorrectSFX
        OnStateTrue -= ScoreManager.instance.AddScore;
        OnStateTrue -= ComboSystem.instance.AddComboNum;
        OnStateTrue -= SoundManager.instance.PlayCorrectSFX;

        //Unsubscribe【Wrong】event: AddScore、AddComboNum、PlayCorrectSFX
        OnStateFalse -= ComboSystem.instance.ResetComboNum;
        OnStateFalse -= SoundManager.instance.PlayWrongSFX;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            StartCoroutine(ResetTheGameobject());
        }

        if (collision.gameObject.tag == "Pan")
        {
           HitPan();
        }
    }

    protected IEnumerator ResetTheGameobject()
    {
        yield return new WaitForSeconds(2f);
        Reset();
    }

    protected void HitPan()
    {
        rb.velocity = VelocityComponent.AverageVelocity;
    }

    protected void StateTrue(AIEventArgs e)
    {
        if (this.OnStateTrue != null)
        {
            OnStateTrue(this.gameObject, e);
        }
    }

    protected void StateFalse(AIEventArgs e)
    {
        if (this.OnStateFalse != null)
        {
            OnStateFalse(this.gameObject, e);
        }
    }
}

//The data we need to pass into methods
public class AIEventArgs : EventArgs
{
    public Pool pool;
    public string poolName;
    public string correctSFX;
    public string wrongSFX;
}
