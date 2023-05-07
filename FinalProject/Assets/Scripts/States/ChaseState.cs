using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool canAttackPlayer;
    public override State RunCurrentState()
    {
        if (canAttackPlayer)
        {
            return attackState;
        } 
        else
        {
            return this;
        }
        
    }
}
