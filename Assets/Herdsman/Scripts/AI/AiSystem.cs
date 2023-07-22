﻿using System;
using System.Collections.Generic;
using Common.GameEntities.Abstract;
using GameEntities.Movement;

namespace AI
{
    public class AiSystem
    {
        private readonly List<AiMediator> mediators = new();

        public void RegisterMediator(IGameEntityMediator mediator)
        {
            AiMediator aiMediator = new AiMediator();

            //check interfaces
            if (mediator is IMovementController movable)
            {
                aiMediator.SetMovementController(movable);
            }
            //Add another interfaces to handle using else if
            else
            {
                throw new ArgumentException($"Can't handle {mediator.GetType()} by AI system!");
            }
        }

        public void ClearMediators()
        {
            foreach (var aiMediator in mediators)
            {
                aiMediator.Dispose();
            }
        }
    }
}