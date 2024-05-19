using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class Angry : MonoBehaviour
{
    public List<Transform> patrolPoints;

    public PlayerController player;

    private NavMeshAgent _navMeshAgent;

    private bool _isPlayerNoticed;

    public float ViewAngle;

    public float damage = 10;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        NewPatrol();
    }

    void Update()
    {
        NoticePlayerUpdate();

        ChaseUpdate();

        NewPatrolUpdate();

        AttackUpdate();
    }

    //decoding_

    private void NewPatrol()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void NewPatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;

        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }

            }
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {

            }
        }

    }

    //_decoding
}
