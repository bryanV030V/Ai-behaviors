using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    public class followPath : Behavior
    {
        public int CurrentPatrolIndex;
        public List<NewWaypoint> _SetWaypoints;

        

        public followPath(List<NewWaypoint> TheseWaypoints)
        {
            _SetWaypoints = TheseWaypoints;
        }
        

       


        public override Vector3 CalculateSteeringForce(float DT, BehaviorContext context)
        {
            Vector3 a = context.PlayerPos;
            a.y = 0f;
            Vector3 b = _SetWaypoints[CurrentPatrolIndex].transform.position;
            b.y = 0f;

            TargetPos = _SetWaypoints[CurrentPatrolIndex].transform.position;
            if(Vector3.Distance(a, b)<= 0.7f)
            {
                CurrentPatrolIndex++;
                Debug.Log("Currentindex " + CurrentPatrolIndex);
            }

            if(CurrentPatrolIndex == 6)
            {
                CurrentPatrolIndex = 0;
            }
           
            
           






            PlayerMoveVelocityNeeded = (TargetPos - context.PlayerPos).normalized * context.GettingStats.MaxDesiredVelocity;
            return PlayerMoveVelocityNeeded - context.Player_velocity;
        }
    }



}


