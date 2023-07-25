using System;
using System.Collections.Generic;
using Common.Utils;
using GameEntities.Movement;
using UnityEngine;

namespace NPC.AI
{
    //Simple realization
    public class AiMovementHanlder : IDisposable
    {
        /// <summary>
        /// For coop mode.
        /// </summary>
        public bool HasFollowTarget { get; private set; }

        public event Action FollowCancelled;
        
        private readonly AiModel aiModel;
        private readonly Dictionary<NpcStateType, NpcStateBase> behaviourStates;
        private Action updateAction;
        private NpcStateBase currentState;

        public AiMovementHanlder(IMovementController movementController,  AiMovementData aiMovementData)
        {
            aiModel = new AiModel(movementController, aiMovementData);
            aiModel.OnStateChanged += OnStateChanged;
            aiModel.OnFollowCanceled = OnFollowCanceled;
            behaviourStates = new()
            {
                { NpcStateType.Patrol , new NpcPatrol(aiModel)},
                { NpcStateType.Follow , new NpcFollow(aiModel)}
            };
        }

        private void OnFollowCanceled()
        {
            FollowCancelled?.Invoke();
        }

        public void SetActive(bool isActive)
        {
            if (isActive)
            {
                CustomGameLoop.OnEarlyUpdate += OnUpdate;
                aiModel.StateType = NpcStateType.Patrol;
            }
            else
            {
                CustomGameLoop.OnEarlyUpdate -= OnUpdate;
                aiModel.StateType = NpcStateType.Idle;
            }
        }

        public void SetTransformToFollow(Transform transform)
        {
            HasFollowTarget = true;
            aiModel.TransformToFollow = transform;
            aiModel.StateType = NpcStateType.Follow;
        }

        public void Dispose()
        {
            SetActive(false);
        }

        private void OnStateChanged()
        {
            if (currentState != null)
            {
                currentState.Stop();
            }

            updateAction = null;
            currentState = null;
            
            aiModel.MovementController.SetSpeed(0);
            aiModel.MovementController.Stop();
            
            if (behaviourStates.TryGetValue(aiModel.StateType, out currentState))
            {
                currentState.Start();
                updateAction = currentState.Update;
            }
        }

        private void OnUpdate()
        {
            updateAction?.Invoke();
        }
    }
}