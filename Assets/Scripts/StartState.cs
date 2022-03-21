using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State
{
    public ChaseState chaseState;
    public bool canSeeThePlayer;
    public override State RunCurrentState()
    {
        //move towards center of map
        //raycast if wall is directly ahead

        if(canSeeThePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }

    }
}
