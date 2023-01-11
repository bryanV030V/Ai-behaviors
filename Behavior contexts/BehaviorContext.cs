using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    public class BehaviorContext
    {
        public Vector3 PlayerPos;
        public Vector3 Player_velocity;
        public PlayerStats GettingStats;


        public BehaviorContext(Vector3 Pos, Vector3 Velocity, PlayerStats GetStats)
        {
            PlayerPos = Pos;
            Player_velocity = Velocity;
            GettingStats = GetStats;
        }

        public GameObject TargetPlayer { get; internal set; }
    }



}


