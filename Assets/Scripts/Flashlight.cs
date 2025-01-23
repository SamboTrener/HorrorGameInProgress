using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float maxTimeLight;
    [SerializeField] AudioClip shakeSound;
    [SerializeField] AudioClip lowBatteryCue;

    Animator animator;
    AudioSource audioSource;
    float timeLight = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (timeLight < maxTimeLight)
        {
            timeLight += Time.deltaTime;
        }
        else
        {
            timeLight = 0f;
            animator.SetTrigger("FixFlashlight");
        }
    }

    private void PlayShakeSound()
    {
        audioSource.PlayOneShot(shakeSound);
    }

    private void PlayLowBatteryCue()
    {
        PlayerSounds.Instance.PlayCue(lowBatteryCue);
    }
}
