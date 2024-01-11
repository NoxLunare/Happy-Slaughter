using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;    
    public AudioSource audioSource;

    public AudioClip audioClipFire;
    public AudioClip audioClipWalking;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

  
    public void StartBurningPlayerSound()
    {
        audioSource.clip = audioClipFire;   
        audioSource.Play();
    }

    public void StopBurningPlayerSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void StartWalkingPlayerSound()
    {
        audioSource.clip = audioClipWalking;
        audioSource.Play();
    }

    public void StopWalkingPlayerSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
