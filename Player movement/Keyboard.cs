using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Steering
{
    public class Keyboard : Behavior
    {
        override public Vector3 CalculateSteeringForce(float DT, BehaviorContext context)
        {
            Vector3 requestedDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if (requestedDirection != Vector3.zero)
                TargetPos = context.PlayerPos + requestedDirection.normalized * context.GettingStats.MaxDesiredVelocity;
            else
                TargetPos = context.PlayerPos;

            PlayerMoveVelocityNeeded = (TargetPos - context.PlayerPos).normalized * context.GettingStats.MaxDesiredVelocity;
            return PlayerMoveVelocityNeeded - context.Player_velocity;
        }

    }



}


