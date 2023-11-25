using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    private AudioSource _audioSource;

    private void Awake()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio);
    }
}
