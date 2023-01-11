using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Steering
{
    public class FleeFromPlayer : Behavior
    {

        public GameObject SetTarget;

        public FleeFromPlayer(GameObject NewTaget)
        {
            SetTarget = NewTaget;
        }

        public override Vector3 CalculateSteeringForce(float DT, BehaviorContext context)
        {
            TargetPos = SetTarget.transform.position;



            PlayerMoveVelocityNeeded = (TargetPos - context.PlayerPos).normalized * context.GettingStats.MaxDesiredVelocity;
            return -PlayerMoveVelocityNeeded - context.Player_velocity;
        }
    }
}

