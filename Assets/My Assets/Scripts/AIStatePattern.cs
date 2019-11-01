using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStatePattern : MonoBehaviour
{
    private NavMeshAgent agent;

    private State currentState;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        SetState(new ReturnHomeState(this));
    }

    private void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;
        gameObject.name = "Cube - " + state.GetType().Name;

        if (currentState != null)
            currentState.OnStateEnter();
    }

    public void MoveToward(Vector3 destination)
    {
        var direction = GetDirection(destination);
        agent.SetDestination(destination);
    }

    private Vector3 GetDirection(Vector3 destination)
    {
        return (destination - transform.position).normalized;
    }
}