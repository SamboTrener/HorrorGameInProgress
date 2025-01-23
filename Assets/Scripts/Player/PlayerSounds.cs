using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public static PlayerSounds Instance {  get; private set; }

    AudioSource source;

    private void Awake()
    {
        Instance = this;

        source = GetComponent<AudioSource>();
    }

    public void PlayCue(AudioClip audioClip)
    {
        if (!source.isPlaying)
        {
            source.PlayOneShot(audioClip);
        }
    }
}
