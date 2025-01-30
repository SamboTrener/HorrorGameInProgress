using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public static PlayerSounds Instance {  get; private set; }

    private AudioSource _source;

    private void Awake()
    {
        Instance = this;

        _source = GetComponent<AudioSource>();
    }

    public void PlayCue(AudioClip audioClip)
    {
        if (!_source.isPlaying)
        {
            _source.PlayOneShot(audioClip);
        }
    }
}
