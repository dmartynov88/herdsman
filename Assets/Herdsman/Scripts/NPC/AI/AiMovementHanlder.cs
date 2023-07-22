using System;
using Common.Utils;
using GameEntities.Movement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NPC.AI
{
    //Simple realization
    public class AiMovementHanlder : IDisposable
    {
        private readonly IMovementController movementController;
        
        //Simple realization of cache start point
        //Rewrite if want to use network player's mediators after connection broken
        private readonly AiMovementData aiMovementData;
        private readonly Vector3 startPoint;
        private Vector3 targetPoint;

        public AiMovementHanlder(IMovementController movementController,  AiMovementData aiMovementData)
        {
            this.movementController = movementController;
            this.aiMovementData = aiMovementData;
            startPoint = movementController.Transform.localPosition;
            
            movementController.SetSpeed(aiMovementData.MovementSpeed);
            
            targetPoint = GenerateTargetPoint();
            movementController.MoveTo(targetPoint);
            CustomGameLoop.OnEarlyUpdate += EarlyUpdate;
        }

        public void Dispose()
        {
            CustomGameLoop.OnEarlyUpdate -= EarlyUpdate;
            movementController.Stop();
        }

        private void EarlyUpdate()
        {
            if (movementController.Transform != null)
            {
                //ToDo optimize or rewrite logic to precached path if needed
                if ((targetPoint - movementController.Transform.localPosition).magnitude <
                    aiMovementData.StoppingDistance)
                {
                    targetPoint = GenerateTargetPoint();
                    movementController.MoveTo(targetPoint);
                }
            }
        }

        private Vector3 GenerateTargetPoint()
        {
            return new Vector3(
                startPoint.x + (RandomValueFrom0To1Generator.Get() * aiMovementData.RandomMovementPosition.x),
                startPoint.y,
                startPoint.z + (RandomValueFrom0To1Generator.Get() * aiMovementData.RandomMovementPosition.z));
        }
    }
}