using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;    

    public AudioSource audioFireSource;
    public AudioSource audioWalkingSource;
    public AudioSource audioShootSource;

    public AudioClip audioClipFire;
    public AudioClip audioClipWalking;
    public AudioClip audioClipShoot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        audioFireSource = GetComponent<AudioSource>();
        audioWalkingSource = GetComponent<AudioSource>();
    }

  
    public void StartBurningPlayerSound()
    {
        audioFireSource.clip = audioClipFire;   
        audioFireSource.Play();
    }
    public void StopBurningPlayerSound()
    {
        if (audioFireSource.isPlaying)
        {
            audioFireSource.Stop();
        }
    }
    public void StartWalkingPlayerSound()
    {
        audioWalkingSource.clip = audioClipWalking;
        audioWalkingSource.Play();
    }
    public void StopWalkingPlayerSound()
    {
        if (audioWalkingSource.isPlaying)
        {
            audioWalkingSource.Stop();
        }
    }
    public void StartShootPlayerSound()
    {
        audioShootSource.clip = audioClipShoot;
        audioShootSource.Play();
    }
    public void StopShootPlayerSound()
    {
        if (audioShootSource.isPlaying)
        {
            audioShootSource.Stop();
        }
    }

}
