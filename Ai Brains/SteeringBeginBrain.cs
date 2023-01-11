using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Steering
{
    using BehaviorList = List<IBehavior>;
    public class SteeringBeginBrain : MonoBehaviour
    {
        [SerializeField] PlayerStats GetStats;
        public BehaviorList This_behaviors = new BehaviorList();
        public string M_lable;


        [Header("SteeringRuntime")]
        public Vector3 PlayerPos = Vector3.zero; //current playerpos  
        public Vector3 PlayerMoveVelocity = Vector3.zero; // current Velocity
        public Vector3 Steering = Vector3.zero; //Needed Steering angle




        public void Start()
        {
            PlayerPos = transform.position;

        }





        private void FixedUpdate()
        {
           

            Steering = Vector3.zero;

            foreach (IBehavior behavior in This_behaviors)
            {
                Steering += behavior.CalculateSteeringForce(Time.fixedDeltaTime, new BehaviorContext(PlayerPos, PlayerMoveVelocity, GetStats));
            }

            Steering.y = 0.0f;


            Steering = Vector3.ClampMagnitude(Steering, GetStats.MaxSteeringForce);
            Steering /= GetStats.Playermass;

            PlayerMoveVelocity = Vector3.ClampMagnitude(PlayerMoveVelocity + Steering, GetStats.MaxSpeed);
            PlayerPos += PlayerMoveVelocity * Time.fixedDeltaTime;

            transform.position = PlayerPos;
            transform.LookAt(PlayerPos + Time.fixedDeltaTime * PlayerMoveVelocity);



        }

        public void SetBehavior(BehaviorList behavior, string lable = "")
        {
            M_lable = lable;
            This_behaviors = behavior;

            foreach(IBehavior behaviors in This_behaviors)
            {
                behaviors.Start(new BehaviorContext(PlayerPos, PlayerMoveVelocity, GetStats));
            }


        }


        public void OnDrawGizmos()
        {

            DrawLableAndGizomos.DrawRay(transform.position, PlayerMoveVelocity, Color.blue);
            DrawLableAndGizomos.DrawLabel(transform.position, name, Color.red);

            foreach (IBehavior behavior in This_behaviors)
            {
                behavior.OnDrawGizmos(new BehaviorContext(PlayerPos, PlayerMoveVelocity, GetStats));
            }


        }
    }



}


