using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Steering
{
    public class MouseClick : Steering.Behavior
    {
        public override Vector3 CalculateSteeringForce(float DT, BehaviorContext context)
        {
         
            if(Input.GetMouseButtonDown(0))
            {
               
               if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
               {
                    TargetPos = hit.point;
                    TargetPos.y = context.PlayerPos.y;

                   

                }
               
            }
            PlayerMoveVelocityNeeded = (TargetPos - context.PlayerPos).normalized * context.GettingStats.MaxDesiredVelocity;
            return PlayerMoveVelocityNeeded - context.Player_velocity;
        }


    }



}


