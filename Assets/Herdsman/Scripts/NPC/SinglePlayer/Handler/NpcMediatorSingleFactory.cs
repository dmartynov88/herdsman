using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using NPC.AI;
using NPC.SinglePlayer.Entity;

namespace NPC.SinglePlayer
{
    public class NpcMediatorSingleFactory : IGameEntityMediatorFactory<NpcSingleMediator, NpcSingleView> 
    {
        private readonly IAiMovementDataProvider aiMovementDataProvider;

        public NpcMediatorSingleFactory(IAiMovementDataProvider aiMovementDataProvider)
        {
            this.aiMovementDataProvider = aiMovementDataProvider;
        }

        public async UniTask<NpcSingleMediator> Create(uint entityId, NpcSingleView view, SpawnData spawnData)
        {
            var mediator = new NpcSingleMediator();
            await mediator.Initialize(entityId, view, spawnData, aiMovementDataProvider.GetMovementData());
            return mediator;
        }
    }
}