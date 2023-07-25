using System;
using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using NPC.AI;

namespace NPC.LocalMode.Entity
{
    public class NpcMediator : GameEntityMediatorBase<NpcView>
    {
        //Class for NPC character logic
        public event Action<int> ReachedYard;
        
        private AiMovementHanlder aiMovementHanlder;
        private AiMovementData aiMovementData;
        private bool yardReached;

        public UniTask Initialize(uint entityId, NpcView view, SpawnData spawnData, AiMovementData aiMovementData)
        {
            this.aiMovementData = aiMovementData;
            yardReached = false;
            return base.Initialize(entityId, view, spawnData);
        }

        protected override void OnViewReady()
        {
            aiMovementHanlder = new AiMovementHanlder(View, aiMovementData);
            View.InteractableTriggered += OnInteractableTriggered;
            aiMovementHanlder.SetActive(true);
        }
        
        private void OnInteractableTriggered(ITriggerDetector triggerDetector)
        {
            if(yardReached)
                return;
            
            if (triggerDetector is PlayerTrigger playerTrigger)
            {
                aiMovementHanlder.SetTransformToFollow(playerTrigger.Transform);
                View.SetColor(playerTrigger.TriggeredColor);
            }
            else if (triggerDetector is YardTrigger yardDetector)
            {
                yardReached = true;
                aiMovementHanlder.SetActive(false);
                ReachedYard?.Invoke(yardDetector.YardTriggerId);
            }
        }

        protected override void OnDestroy()
        {
            View.InteractableTriggered -= OnInteractableTriggered;
            aiMovementHanlder?.Dispose();
        }
    }
}
