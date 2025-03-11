using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float detectionRange;
    [SerializeField] private float chaseDuration;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float attackDistance;
    
    private NavMeshAgent _agent;
    private Vector3 _destination;
    private float _chaseTimer;
    
    public Action OnStateChanged;
    
    public EnemyState EnemyState { get; private set; }
    
    public void SetEnemyState(EnemyState state)
    {
        EnemyState = state;
        OnStateChanged?.Invoke();
    }
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, PlayerMotor.Instance.transform.position);
        if (IsPlayerReachable(distanceToPlayer))
        {
            if (EnemyState != EnemyState.Chasing)
            {
                StartChase();
            }
        }
        
        switch (EnemyState)
        {
            case EnemyState.Walking:
                _agent.isStopped = false;
                _agent.speed = walkSpeed;
                if (Vector3.Distance(transform.position, _destination) < 0.1f)
                {
                    UpdateDestination();
                }
                break;
            case EnemyState.Chasing:
                _agent.isStopped = false;
                _agent.speed = chaseSpeed;
                _agent.SetDestination(PlayerMotor.Instance.transform.position);
                _chaseTimer -= Time.deltaTime;

                if (Vector3.Distance(transform.position, PlayerMotor.Instance.transform.position) < attackDistance)
                {
                    GameManager.Instance.LooseGame();
                    Destroy(gameObject); //not to invoke loose game 1000 times
                }
                
                if (_chaseTimer <= 0 && IsPlayerReachable(distanceToPlayer))
                {
                    _chaseTimer = chaseDuration;
                }
                
                if (_chaseTimer <= 0 || distanceToPlayer >= detectionRange || PlayerStateMachine.Instance.PlayerState == PlayerState.Hiding)
                {
                    EndChase();
                    UpdateDestination();
                }
                break;
            case EnemyState.LostTarget:
                _agent.isStopped = true;
                break;
        }
    }

    private bool IsPlayerReachable(float distanceToPlayer)
    {
        if (distanceToPlayer <= detectionRange && PlayerStateMachine.Instance.PlayerState != PlayerState.Hiding)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, PlayerMotor.Instance.transform.position - transform.position,
                    out hit, detectionRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    private void UpdateDestination()
    {
        _destination = waypoints[Random.Range(0, waypoints.Length)].position;
        _agent.SetDestination(_destination);
    }

    private void StartChase()
    {
        EnemyState = EnemyState.Chasing;
        OnStateChanged?.Invoke();
        _chaseTimer = chaseDuration;
    }

    void EndChase()
    {
        EnemyState = EnemyState.LostTarget;
        OnStateChanged?.Invoke();
        UpdateDestination();
    }
}
