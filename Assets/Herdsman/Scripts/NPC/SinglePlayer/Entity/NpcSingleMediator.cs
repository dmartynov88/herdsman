using System;
using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using NPC.AI;

namespace NPC.SinglePlayer.Entity
{
    public class NpcSingleMediator : GameEntityMediatorBase<NpcSingleView>
    {
        public event Action ReachedYard;
        
        private AiMovementHanlder aiMovementHanlder;
        private AiMovementData aiMovementData;

        public UniTask Initialize(uint entityId, NpcSingleView view, SpawnData spawnData, AiMovementData aiMovementData)
        {
            this.aiMovementData = aiMovementData;
            return base.Initialize(entityId, view, spawnData);
        }

        //Class for NPC character logic
        protected override void OnViewReady()
        {
            aiMovementHanlder = new AiMovementHanlder(View, aiMovementData);
            View.InteractableTriggered += OnInteractableTriggered;
            aiMovementHanlder.SetActive(true);
        }

        private void OnInteractableTriggered(ITriggerDetector triggerDetector)
        {
            if (triggerDetector is PlayerTrigger)
            {
                aiMovementHanlder.SetTransformToFollow(triggerDetector.Transform);
            }
            else if (triggerDetector is YardTrigger)
            {
                aiMovementHanlder.SetActive(false);
                ReachedYard?.Invoke();
            }
        }

        protected override void OnDestroy()
        {
            View.InteractableTriggered -= OnInteractableTriggered;
            aiMovementHanlder?.Dispose();
        }
    }
}
