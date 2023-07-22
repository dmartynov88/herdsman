using UnityEngine;

namespace NPC.AI
{
    public class NpcFollow : NpcStateBase
    {
        private readonly AiModel aiModel;
        private readonly Vector3 startPoint;
        
        private readonly Vector3 range;
        private readonly Transform transform;
        private readonly float stoppingDist;
        private readonly float followDist;
        private readonly float speed;

        public NpcFollow(AiModel aiModel)
        {
            this.aiModel = aiModel;
            transform = aiModel.MovementController.Transform;
            startPoint = transform.localPosition;
            range = aiModel.AiMovementData.RandomMovementPosition;
            stoppingDist = aiModel.AiMovementData.StoppingDistance;
            followDist = aiModel.AiMovementData.FollowDistance;
            speed = aiModel.AiMovementData.FollowSpeed;
            
        }
        
        public override void Start()
        {
            aiModel.MovementController.SetSpeed(speed);
        }

        public override void Stop()
        {
            aiModel.MovementController.SetSpeed(0);
        }
        
        public override void Update()
        {
            if (aiModel.TransformToFollow != null)
            {
                if ((aiModel.TransformToFollow.position - transform.localPosition).magnitude < stoppingDist)
                {
                    aiModel.MovementController.Stop();
                    return;
                }
                if ((aiModel.TransformToFollow.position - transform.localPosition).magnitude > followDist)
                {
                    aiModel.StateType = NpcStateType.Patrol;
                    return;
                }
                aiModel.MovementController.MoveTo(aiModel.TransformToFollow.position);
            }
            else
            {
                aiModel.StateType = NpcStateType.Patrol;
            }
        }
    }
}