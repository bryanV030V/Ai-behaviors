using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Steering
{
    [RequireComponent(typeof(SteeringBeginBrain))]
    public class SimpleBrain : MonoBehaviour
    {
        public enum BehaviorEnums { KeyBoard, seekClickPoint, Seek, flee, pursue, Evade, wander, followPath, hide, Notset }

        [Header("Manual")]
        public BehaviorEnums m_behavior;
        public GameObject m_target;


        [SerializeField] List<NewWaypoint> _patrolpoints = new List<NewWaypoint>();

        [Header("Private")]
        private SteeringBeginBrain steering;

        //_________________________________________________________\\
        //_________________________________________________________\\
        //_________________________________________________________\\

        public SimpleBrain()
        {
            m_behavior = BehaviorEnums.Notset;
            m_target = null;
        }
        public void Awake()
        {
          
        }


        public void Update()
        {

           


            
        }



        public void Start()
        {



            if(m_behavior == BehaviorEnums.KeyBoard  || m_behavior == BehaviorEnums.seekClickPoint)
            {
                m_target = null;
            }
            else
            {
                if (m_target == null)
                    m_target = GameObject.Find("Player");
                if (m_target == null)
                    m_target = GameObject.Find("Targets");
            }

            steering = GetComponent<SteeringBeginBrain>();

            List<IBehavior> behaviors = new List<IBehavior>();
            switch(m_behavior)
            {
                    case BehaviorEnums.KeyBoard:
                    {
                        behaviors.Add(new Keyboard());
                        steering.SetBehavior(behaviors, "Keyboard");
                       
                    }
                    break;

                    case BehaviorEnums.seekClickPoint:
                    {
                        behaviors.Add(new MouseClick());
                        steering.SetBehavior(behaviors, "seekClickPoint");
                    }
                    break;

                    case BehaviorEnums.Seek:
                    {
                        behaviors.Add(new Seek(m_target));
                        steering.SetBehavior(behaviors, "Seeking");
                    }     
                    break;

                case BehaviorEnums.followPath:
                    {
                        behaviors.Add(new followPath(_patrolpoints));
                        steering.SetBehavior(behaviors, "Following");
                    }
                    break;


                    case BehaviorEnums.pursue:
                    {
                        behaviors.Add(new followplayer(m_target));
                        steering.SetBehavior(behaviors, "follow player");
                        
                    }
                    break;


                case BehaviorEnums.flee:
                    {
                        behaviors.Add(new FleeFromPlayer(m_target));
                        steering.SetBehavior(behaviors, "follow player");

                    }
                    break;














            }
           
            


        }


    }
}


