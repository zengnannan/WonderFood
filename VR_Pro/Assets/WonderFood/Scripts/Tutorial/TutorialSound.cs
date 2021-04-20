using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;
using  System;

public class TutorialSound : MonoBehaviour
{
    public List<AudioClip> TutorialAudioClips_English;
    public List<AudioClip> TutorialAudioClips_Chinese;
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int i)
    {
        if (PlayerPrefs.GetInt("Language") == 1)
        {
          audioSource.PlayOneShot(TutorialAudioClips_English[i - 1]);  
        }

        if (PlayerPrefs.GetInt("Language") == 0)
        {
            audioSource.PlayOneShot(TutorialAudioClips_Chinese[i - 1]);
        }

    }

    public void PlaySound(int i, UnityAction callback = null)
    {
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            var clip = TutorialAudioClips_English[i - 1];
            audioSource.PlayOneShot(clip);
            StartCoroutine(AudioPlayFinished(clip.length, callback));
        }

        if (PlayerPrefs.GetInt("Language") == 0)
        {
            var clip = TutorialAudioClips_Chinese[i - 1];
            audioSource.PlayOneShot(clip);
            StartCoroutine(AudioPlayFinished(clip.length, callback));
        }
    }

    private IEnumerator AudioPlayFinished(float time, UnityAction callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }
}
