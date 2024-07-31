using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip JumpSFX;
    public float JumpSFXVolume = 1.0f;
    public AudioClip ShootSFX;
    public float ShootSFXVolume = 1.0f;
    public AudioClip DashSFX;
    public float DashSFXVolume = 1.0f;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        // Initialize the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }

    public void PlayJumpSound()
    {
        PlaySound(JumpSFX, JumpSFXVolume);
    }
    public void PlayDashSound()
    {
        PlaySound(DashSFX, DashSFXVolume);
    }
    public void PlayShootSound()
    {
        PlaySound(ShootSFX, ShootSFXVolume);
    }
}