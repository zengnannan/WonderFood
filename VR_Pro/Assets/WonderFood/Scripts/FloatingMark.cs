using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMark : MonoBehaviour
{

    private GameObject Player;

    void Start()
    {
        Player = GameObject.Find("XR Rig");

    }
    void Update()
    {
        this.gameObject.transform.forward= Player.transform.position - transform.position;
        if (gameObject.GetComponentInParent<AIBase>().isHit==true&& gameObject.GetComponentInParent<AIBase>().isGrounded==true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }



}
