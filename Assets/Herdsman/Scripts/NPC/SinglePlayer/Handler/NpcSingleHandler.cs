using System.Collections.Generic;
using Adic;
using NPC.AI;
using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using NPC.SinglePlayer.Entity;

namespace NPC.SinglePlayer
{
    public class NpcSingleHandler : GameEntityHandlerBase<NpcSingleMediator, NpcSingleView>
    {
        private readonly List<NpcSingleMediator> mediators = new();
        
        public NpcSingleHandler(GameEntitySpawner<NpcSingleMediator, NpcSingleView> spawner) : base(spawner)
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
                DestroyMediator(mediator);
            }
            mediators.Clear();
        }
        
        private async UniTask CreateNpc(SpawnData spawnData)
        {
            var mediator = await CreateMediator(0, spawnData);
            SubscribeToMediatorEvents(mediator);
            
            mediators.Add(mediator);
        }
        
        private void SubscribeToMediatorEvents(NpcSingleMediator mediator)
        {
            //ToDo subscribe to events
        }
        
        private void UnsubscribeFromMediatorEvents(NpcSingleMediator mediator)
        {
            //ToDo Unsubscribe from events
        }
    }
}
