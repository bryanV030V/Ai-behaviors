using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    public interface IBehavior
    {
        /// <summary
        /// Allow the behavior to initialize
        /// </summart>
        /// <param name="context"> All the context information needed to perform the task at hand.</parm>

        void Start(BehaviorContext context);


        ///<summary>
        ///Calcukate the steeringforce gotten from this behavior
        ///</summary>
        /// <param name="DT"> the deltaTime for this step </param>
        /// <param name="Context"> all the context info is needed to perform the task at hand. </param>
        /// <returns></returns>


        Vector3 CalculateSteeringForce(float DT, BehaviorContext context);


        ///<summary>
        ///Draw the gizoms from this Behavior
        /// </summary>
        /// <param name="context">All the context info needed to perform the task at hand. </param>
        /// 

        void OnDrawGizmos(BehaviorContext context);























    }



}


