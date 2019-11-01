using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected AIStatePattern AI;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(AIStatePattern AI)
    {
        this.AI = AI;
    }
}