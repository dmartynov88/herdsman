using Common.Utils;
using UnityEngine;

namespace NPC.AI
{
    public class NpcPatrol : NpcStateBase
    {
        private readonly AiModel aiModel;
        private readonly Vector3 startPoint;
        
        private readonly Vector3 range;
        private readonly Transform transform;
        private readonly float stoppingDist;
        private readonly float speed;
        private Vector3 targetPoint;

        public NpcPatrol(AiModel aiModel)
        {
            this.aiModel = aiModel;
            transform = aiModel.MovementController.Transform;
            startPoint = transform.localPosition;
            range = aiModel.AiMovementData.RandomMovementPosition;
            stoppingDist = aiModel.AiMovementData.StoppingDistance;
            speed = aiModel.AiMovementData.MovementSpeed;
            
        }


        public override void Start()
        {
            targetPoint = GenerateTargetPoint();
            aiModel.MovementController.SetSpeed(speed);
            aiModel.MovementController.MoveTo(targetPoint);
        }

        public override void Update()
        {
            if (transform != null)
            {
                //ToDo optimize or rewrite logic to precached path if needed
                if ((targetPoint - transform.localPosition).magnitude < stoppingDist)
                {
                    targetPoint = GenerateTargetPoint();
                    aiModel.MovementController.MoveTo(targetPoint);
                }
            }
        }

        public override void Stop()
        {
            
        }

        private Vector3 GenerateTargetPoint()
        {
            return new Vector3(
                startPoint.x + (RandomValueFrom0To1Generator.Get() * range.x),
                startPoint.y,
                startPoint.z + (RandomValueFrom0To1Generator.Get() * range.z));
        }
    }
}