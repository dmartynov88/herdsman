using System.Collections.Generic;
using Adic;
using AI;
using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using NPC.Entity;

namespace NPC.SinglePlayer
{
    public class NpcSingleHandler : GameEntityHandlerBase<NpcMediator, NpcView>
    {
        [Inject] private AiSystem AiSystem { get; set; }
        private readonly List<NpcMediator> mediators = new();

        
        public NpcSingleHandler(GameEntitySpawner<NpcMediator, NpcView> spawner) : base(spawner)
        {
        }
        
        
        public UniTask CreateNpcs(List<SpawnData> spawnDatas)
        {
            var tasksList = new List<UniTask>();

            foreach (var spawnData in spawnDatas)
            {
                tasksList.Add(CreateNpc(spawnData));
            }

            return UniTask.WhenAll(tasksList);
        }

        public void DestroyNpcs()
        {
            foreach (var mediator in mediators)
            {
                UnsubscribeFromMediatorEvents(mediator);
                AiSystem.ClearMediators();
                DestroyMediator(mediator);
            }
            mediators.Clear();
        }
        
        private async UniTask CreateNpc(SpawnData spawnData)
        {
            var mediator = await CreateMediator(0, spawnData);
            AiSystem.RegisterMediator(mediator);
            SubscribeToMediatorEvents(mediator);
            
            mediators.Add(mediator);
        }
        
        private void SubscribeToMediatorEvents(NpcMediator mediator)
        {
            //ToDo subscribe to events
        }
        
        private void UnsubscribeFromMediatorEvents(NpcMediator mediator)
        {
            //ToDo Unsubscribe from events
        }
    }
}
