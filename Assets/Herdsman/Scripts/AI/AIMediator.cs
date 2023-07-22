using System;
using GameEntities.Movement;

namespace AI
{
    public class AIMediator : IDisposable
    {
        //register mediator as group of interfaces
        //Add custom interfaces by Character possibilities
        //For example create IFire and realize NpcMediator, register Npc as IFire

        private AIMovement aiMovement;

        public void RegisterPositionReceiver(IMovementController movemetController)
        {
            aiMovement = new AIMovement(movemetController);
        }

        public void Dispose()
        {
            aiMovement?.Dispose();
        }
    }

    public class AIMovement : IDisposable
    {
        private readonly IMovementController movementController;

        public AIMovement(IMovementController movementController)
        {
            this.movementController = movementController;
        }

        public void Dispose()
        {
            movementController.Stop();
        }
    }
}