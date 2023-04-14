using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _volume=0.5f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _audioSource.volume = _volume;
    }

    public void SetVolume(float vol)
    {
        _volume = vol;
    }
}
