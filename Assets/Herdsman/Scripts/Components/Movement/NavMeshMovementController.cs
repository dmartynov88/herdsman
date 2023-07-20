using GameEntities.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace Components.Movement
{
    public class NavMeshMovementController : MovementControllerBase
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform transform;
        
        
        public override void SetPosition(Vector3 position)
        {
            agent.isStopped = true;
            agent.ResetPath();
            transform.localPosition = position;
        }

        public override void MoveTo(Vector3 target)
        {
            if (agent.isStopped)
            {
                agent.isStopped = false;
            }
            
            agent.SetDestination(target);
        }

        public override void Stop()
        {
            agent.ResetPath();
            agent.isStopped = true;
        }
    }
}