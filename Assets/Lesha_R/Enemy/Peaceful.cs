using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class Peaceful : MonoBehaviour
{
    public List<Transform> patrolPoints;

    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        NewPatrol();
    }

    void Update()
    {
        NewPatrolUpdate();
    }

    //decoding_

    private void NewPatrol()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void NewPatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        }
    }

    //_decoding
}