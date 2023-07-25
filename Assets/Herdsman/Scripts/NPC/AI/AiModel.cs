using System;
using GameEntities.Movement;
using UnityEngine;

namespace NPC.AI
{
    public class AiModel
    {
        public Action OnFollowCanceled;
        public Action OnStateChanged;
        public IMovementController MovementController { get; private set; }
        public AiMovementData AiMovementData { get; private set; }

        public NpcStateType StateType
        {
            get => currentStateType;
            set
            {
                if (currentStateType != value)
                {
                    currentStateType = value;
                    OnStateChanged?.Invoke();
                }
            }
        }
        private NpcStateType currentStateType = NpcStateType.Idle;

        public Transform TransformToFollow { get; set; }

        public AiModel(IMovementController movementController, AiMovementData aiMovementData)
        {
            MovementController = movementController;
            AiMovementData = aiMovementData;
        }
    }
}