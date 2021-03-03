using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private void Awake()
    {
        instance = this;
    }
    
    public void PlayBrickSound()
    {
        audioSource.clip = audioClips[Random.Range(0, 3)];
        audioSource.Play();
    }

    public void PlaySound()
    {
        audioSource.clip = audioClips[3];
        audioSource.Play();
    }
}
