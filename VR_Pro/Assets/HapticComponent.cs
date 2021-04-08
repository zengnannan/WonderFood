using UnityEngine;
using UnityEngine.XR;
using System;
//using InputDevice = UnityEngine.XR.InputDevice;

public class HapticComponent : MonoBehaviour
{
    public static HapticComponent instance; 

    private InputDevice rightDevice;
    private InputDevice leftDevice;
    [SerializeField] private uint channel;
    [SerializeField] private float amplitudeLeft;
    [SerializeField] private float amplitudeRight;
    [SerializeField] private float duration;
    void Start()
    {
        instance = this;
        rightDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        leftDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

    }
    public void ActivateLeftHaptic(object _sender, EventArgs _e)
    {
        GameObject ai = _sender as GameObject;
        AIEventArgs e = _e as AIEventArgs;
        HapticCapabilities capabilities;

        if (leftDevice.TryGetHapticCapabilities(out capabilities))
        {
            if (capabilities.supportsImpulse)
            {
                leftDevice.SendHapticImpulse(channel, amplitudeLeft, duration);
            }
        }
    }
    public void ActivateRightHaptic(object _sender, EventArgs _e)
    {
        GameObject ai = _sender as GameObject;
        AIEventArgs e = _e as AIEventArgs;
        HapticCapabilities capabilities;

        if (rightDevice.TryGetHapticCapabilities(out capabilities))
        {
            if (capabilities.supportsImpulse)
            {
                rightDevice.SendHapticImpulse(channel, amplitudeRight, duration);
            }
        }
    }

}
