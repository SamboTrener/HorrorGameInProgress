using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private float maxTimeLight;
    [SerializeField] private AudioClip shakeSound;
    [SerializeField] private AudioClip lowBatteryCue;

    private static readonly int FixFlashlight = Animator.StringToHash("FixFlashlight");
    private Animator _animator;
    private AudioSource _audioSource;
    private float _timeLight = 0f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_timeLight < maxTimeLight)
        {
            _timeLight += Time.deltaTime;
        }
        else
        {
            _timeLight = 0f;
            _animator.SetTrigger(FixFlashlight);
        }
    }

    private void PlayShakeSound()
    {
        _audioSource.PlayOneShot(shakeSound);
    }

    private void PlayLowBatteryCue()
    {
        PlayerSounds.Instance.PlayCue(lowBatteryCue);
    }
}
