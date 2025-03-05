using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private static readonly int IsChasing = Animator.StringToHash("IsRunning");
    private EnemyAI _enemy;
    private Animator _animator;

    private void Awake()
    {
        _enemy = GetComponent<EnemyAI>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _enemy.OnChaseStarted += StartChaseAnimation;
        _enemy.OnChaseEnded += EndChaseAnimation;
    }

    private void OnDestroy()
    {
        _enemy.OnChaseStarted -= StartChaseAnimation;
        _enemy.OnChaseEnded -= EndChaseAnimation;
    }

    void StartChaseAnimation()
    {
        _animator.SetBool(IsChasing, true);
    }

    void EndChaseAnimation()
    {
        _animator.SetBool(IsChasing, false);
    }
}
