using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Continue : RotatingButton
{
    protected override void OnTriggerStay(Collider col)
    {
        base.OnTriggerStay(col);
        if (V3Ope.BiggerV3(transform.localScale, new Vector3(ChangedScale - 0.01f, ChangedScale - 0.01f, ChangedScale - 0.01f)))
        {
            var index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index+1);
        }
    }


}
