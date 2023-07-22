using System;
using Common.Utils;
using GameEntities.Movement;
using UnityEngine;

namespace AI
{
    public class AiMovementHanlder : IDisposable
    {
        private readonly IMovementController movementController;

        public AiMovementHanlder(IMovementController movementController)
        {
            this.movementController = movementController;
            CustomGameLoop.OnEarlyUpdate += EarlyUpdate;
        }

        public void Dispose()
        {
            CustomGameLoop.OnEarlyUpdate -= EarlyUpdate;
            movementController.Stop();
        }

        public void EarlyUpdate()
        {
            if (movementController.Transform != null)
            {
                
            }
        }
    }
}