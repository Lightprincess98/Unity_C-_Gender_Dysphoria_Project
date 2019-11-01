using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    private Vector3 nextDestination;

    private float wanderTime = 5f;

    private float timer;

    public WanderState(AIStatePattern AI) : base(AI)
    {
    }

    public override void OnStateEnter()
    {
        nextDestination = GetRandomDestination();
        timer = 0f;
        //AI.GetComponent<Renderer>().material.color = Color.green;
    }

    private Vector3 GetRandomDestination()
    {
        return new Vector3(
            UnityEngine.Random.Range(-500, 500),
            0f,
            UnityEngine.Random.Range(-500, 500)
            );
    }

    public override void Tick()
    {
        if (ReachedDestination())
        {
            nextDestination = GetRandomDestination();
        }

        AI.MoveToward(nextDestination);

        timer += Time.deltaTime;
        if (timer >= wanderTime)
        {
            AI.SetState(new ReturnHomeState(AI));
        }
    }

    private bool ReachedDestination()
    {
        return Vector3.Distance(AI.transform.position, nextDestination) < 0.5f;
    }
}
