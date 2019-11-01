using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReturnHomeState : State
{
    private Vector3 destination;
    private GameObject target;

    public ReturnHomeState(AIStatePattern AI) : base(AI)
    {
    }

    public override void Tick()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        destination = target.transform.position;
        AI.MoveToward(destination);

        if (ReachedHome())
        {
            AI.SetState(new WanderState(AI));
        }
    }

    public override void OnStateEnter()
    {
        //AI.GetComponent<Renderer>().material.color = Color.blue;
    }

    private bool ReachedHome()
    {
        return Vector3.Distance(AI.transform.position, destination) < 0.5f;
    }
}
