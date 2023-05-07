using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool canSeePlayer;
    public Transform target;

    public override State RunCurrentState()
    {
        if (canSeePlayer)
        {
            return chaseState;
        } 
        else
        {
            return this;
        }

        
    }

    private void LookAtTarget()
    {
        Vector3 lookPosition = target.position - transform.position;
        lookPosition.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);

    }
}
