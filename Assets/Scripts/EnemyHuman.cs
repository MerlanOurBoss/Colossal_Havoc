using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHuman : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;

    private int destPoint = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();
    }
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
    private void GotoNextPoint()
    {
        if (_patrolPoints.Length == 0)
            return;

        agent.destination = _patrolPoints[destPoint].position;

        destPoint = (destPoint + 1) % _patrolPoints.Length;
    }
}
