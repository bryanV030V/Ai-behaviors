using System.Collections;
using System.Collections.Generic;
using UnityEngine;





namespace Steering
{
    public class followplayer : Behavior
    {
        public GameObject SetTarget;
        public float distance = 50f;
        public followplayer(GameObject Player)
        {
            SetTarget = Player;
        }


        public override Vector3 CalculateSteeringForce(float DT, BehaviorContext context)
        {
            Vector3 a = context.PlayerPos;
            a.y = 0f;
            Vector3 b = SetTarget.transform.position;
            b.y = 0f;

            TargetPos = SetTarget.transform.position;
            if (Mathf.Abs(Vector3.Distance(context.PlayerPos, SetTarget.transform.position)) <= 0)
            {
                
            }




            //TargetPos = SetTarget.transform.position;



            PlayerMoveVelocityNeeded = (TargetPos - context.PlayerPos).normalized * context.GettingStats.MaxDesiredVelocity;
            return PlayerMoveVelocityNeeded - context.Player_velocity;


        }
    }





}




