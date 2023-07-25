using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using NPC.AI;

namespace NPC.LocalMode.Entity
{
    public class NpcMediatorSingleFactory : IGameEntityMediatorFactory<NpcMediator, NpcView> 
    {
        private readonly IAiMovementDataProvider aiMovementDataProvider;

        public NpcMediatorSingleFactory(IAiMovementDataProvider aiMovementDataProvider)
        {
            this.aiMovementDataProvider = aiMovementDataProvider;
        }

        public async UniTask<NpcMediator> Create(uint entityId, NpcView view, SpawnData spawnData)
        {
            var mediator = new NpcMediator();
            await mediator.Initialize(entityId, view, spawnData, aiMovementDataProvider.GetMovementData());
            return mediator;
        }
    }
}