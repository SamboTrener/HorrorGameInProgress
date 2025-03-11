using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private static readonly int IsChasing = Animator.StringToHash("IsChasing");
    
    private EnemyAI _enemy;
    private Animator _animator;
    private EnemyState _previousState;
    
    private void Awake()
    {
        _enemy = GetComponent<EnemyAI>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (_enemy.EnemyState)
        {
            case EnemyState.Chasing:
                if (_previousState == EnemyState.LostTarget)
                {
                    SetChasingState();
                }
                _previousState = EnemyState.Chasing;
                if (!_animator.GetBool(IsChasing))
                {
                    _animator.SetBool(IsChasing, true);
                }
                break;
            case EnemyState.LostTarget:
                _previousState = EnemyState.LostTarget;
                if (_animator.GetBool(IsChasing))
                {
                    _animator.SetBool(IsChasing, false);
                }
                break;
            case EnemyState.Walking:
                _previousState = EnemyState.Walking;
                break;
        }
    }

    private void SetWalkingState() //Invoke from lost target animation
    {
        _enemy.SetEnemyState(EnemyState.Walking);
    }

    private void SetChasingState()
    {
        _enemy.SetEnemyState(EnemyState.Chasing);
    }
}