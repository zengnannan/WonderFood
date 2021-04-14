using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;
using  System;

public class TutorialSound : MonoBehaviour
{
    public List<AudioClip> TutorialAudioClips;
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int i)
    {
        audioSource.PlayOneShot(TutorialAudioClips[i - 1]);
    }

    public void PlaySound(int i, UnityAction callback = null)
    {
        var clip = TutorialAudioClips[i - 1];
        audioSource.PlayOneShot(clip);
        StartCoroutine(AudioPlayFinished(clip.length, callback));
    }

    private IEnumerator AudioPlayFinished(float time, UnityAction callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }
}
