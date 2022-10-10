using System;
using UnityEngine;

[Serializable]
public class SoundSettings
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;

    public AudioClip Sound => _sound;
    public float MinPitch => _minPitch;
    public float MaxPitch => _maxPitch;

    public void TryPlaySound(AudioSource audioSource)
    {
        audioSource.pitch = UnityEngine.Random.Range(MinPitch, MaxPitch);
        audioSource.Play();
    }
}
