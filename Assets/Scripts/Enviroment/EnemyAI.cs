using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float detectionRange;
    [SerializeField] private float chaseDuration;
    
    private NavMeshAgent _agent;
    private Vector3 _destination;
    private float _chaseTimer;
    private bool _isChasing;

    public Action OnChaseStarted;
    public Action OnChaseEnded;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, PlayerMotor.Instance.transform.position);
        if (distanceToPlayer <= detectionRange && PlayerStateMachine.Instance.PlayerState != PlayerState.Hiding)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, PlayerMotor.Instance.transform.position - transform.position,
                    out hit, detectionRange))
            {
                if (hit.collider.GetComponent<PlayerMotor>())
                {
                    if (!_isChasing)
                    {
                        StartChase();
                    }
                }
            }
        }

        if (_isChasing)
        {
            _agent.SetDestination(PlayerMotor.Instance.transform.position);
            _chaseTimer -= Time.deltaTime;

            if (_chaseTimer <= 0 || distanceToPlayer >= detectionRange || PlayerStateMachine.Instance.PlayerState == PlayerState.Hiding)
            {
                EndChase();
                UpdateDestination();
            }
        }
        else if (Vector3.Distance(transform.position, _destination) < 0.1f)
        {
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        _destination = waypoints[Random.Range(0, waypoints.Length)].position;
        _agent.SetDestination(_destination);
    }

    void StartChase()
    {
        _isChasing = true;
        _chaseTimer = chaseDuration;
        //Animations and sounds of chase start 
        OnChaseStarted?.Invoke();
    }

    void EndChase()
    {
        _isChasing = false;
        OnChaseEnded?.Invoke();
    }
}
