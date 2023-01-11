using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    public abstract class Behavior: IBehavior
    {
        [Header("Behavior In Runtime")]
        public Vector3 TargetPos = Vector3.zero; //Needed Targetpos
        public Vector3 PlayerMoveVelocityNeeded = Vector3.zero; // Needed Velocity
       

        //___________________________________________________________________________
        //___________________________________________________________________________
        public virtual void Start(BehaviorContext context)
        {
            TargetPos = context.PlayerPos;
          
        }
        //___________________________________________________________________________
        //___________________________________________________________________________2
        public abstract Vector3 CalculateSteeringForce(float DT, BehaviorContext context);
        //___________________________________________________________________________
       
            
            
       //___________________________________________________________________________

        public virtual void OnDrawGizmos(BehaviorContext context)
        {
            DrawLableAndGizomos.DrawRay(TargetPos, PlayerMoveVelocityNeeded, Color.red);
        }


        //___________________________________________________________________________
        //___________________________________________________________________________
    }


}


