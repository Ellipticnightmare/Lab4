using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool playerInSight;
    public bool wallInSight;
    public bool headquartersInSight;
    public override State RunCurrentState()
    {
        if(playerInSight || wallInSight || headquartersInSight)
        {
            // move towards player/wall/headquarters
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
