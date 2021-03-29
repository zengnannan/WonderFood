using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour
{

    public static Vibration singleton;

    void Start()
    {
        if (singleton&&singleton!=this)
        {
            Destroy(this);
        }
        else
        {

            singleton = this;
        }
    }
    public void TriggerVibration(AudioClip vibrationAudio, OVRInput.Controller controller)
    {
        Debug.Log("Enter vibration");

        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio);
        if (controller==OVRInput.Controller.LTouch)
        {
            {
                OVRHaptics.LeftChannel.Preempt(clip);
            }
        }
        if (controller == OVRInput.Controller.RTouch)
        {
            {
                OVRHaptics.RightChannel.Preempt(clip);
            }
        }
    }
}
