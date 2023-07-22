using Common.GameEntities.Abstract;
using Common.GameEntities.Character;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using NPC.AI;

namespace NPC.SinglePlayer.Entity
{
    public class NpcSingleMediator : GameEntityMediatorBase<NpcSingleView>
    {
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
        }

        protected override void OnDestroy()
        {
            aiMovementHanlder?.Dispose();
        }
    }
}
