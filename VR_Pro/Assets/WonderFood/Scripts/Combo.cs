using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    private Animator anim;


    void Awake()
    {
        gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

    void PlayCombo()
    {
        
    }

    void DestroyCombo()
    {
        
    }
}
