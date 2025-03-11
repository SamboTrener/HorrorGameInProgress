using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientController : MonoBehaviour
{
    [SerializeField] private AudioClip ambient;
    [SerializeField] private AudioClip chaseAmbient;
    [SerializeField] private EnemyAI enemy;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        enemy.OnStateChanged += ChangeAmbient;
    }

    private void OnDisable()
    {
        enemy.OnStateChanged -= ChangeAmbient;
    }

    private void ChangeAmbient()
    {
        switch (enemy.EnemyState)
        {
            case EnemyState.Chasing:
                _audioSource.clip = chaseAmbient;
                _audioSource.Play();
                break;
            case EnemyState.Walking:
                _audioSource.clip = ambient;
                _audioSource.Play();
                break;
            case EnemyState.LostTarget:
                _audioSource.clip = null;
                break;
        }
    }
}