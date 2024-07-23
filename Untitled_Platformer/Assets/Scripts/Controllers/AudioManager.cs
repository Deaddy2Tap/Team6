using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip JumpSFX;
    public float JumpSFXVolume;

    [SerializeField] List<AudioSource> AudioSources;

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
    }

    void Start()
    {

    }

    private void PlaySound(AudioClip clip, float volume)
    {
        int nextSource = 0;
        Debug.Log(AudioSources.Count);
        math.clamp(nextSource, 0, AudioSources.Count);
        AudioSources[nextSource].PlayOneShot(clip, volume);
        nextSource++;
    }

    public void PlayJumpSound()
    {
        PlaySound(JumpSFX, JumpSFXVolume);
    }
}