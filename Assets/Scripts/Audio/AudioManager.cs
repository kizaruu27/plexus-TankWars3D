using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip explosionClip;

    public void PlayAudioShoot()
    {
        audioSource.PlayOneShot(shootClip);
    }

    public void PlayAudioExplosion()
    {
        audioSource.PlayOneShot(explosionClip);
    }
}
