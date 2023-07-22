using System;
using GameEntities.Movement;

namespace AI
{
    public class AiMediator : IDisposable
    {
        //register mediator as group of interfaces
        //Add custom interfaces by Character possibilities
        //For example create IFire and realize NpcMediator, register Npc as IFire

        private AiMovementHanlder aiMovementHanlder;
        

        public void SetMovementController(IMovementController movemetController, AiMovementData aiMovementData)
        {
            aiMovementHanlder = new AiMovementHanlder(movemetController, aiMovementData);
        }

        public void Dispose()
        {
            aiMovementHanlder?.Dispose();
        }
    }
}