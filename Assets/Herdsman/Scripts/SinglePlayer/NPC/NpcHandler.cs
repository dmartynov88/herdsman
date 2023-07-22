using System.Collections.Generic;
using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using NPC.Entity;

namespace NPC
{
    public class NpcHandler : GameEntityHandlerBase<NpcMediator, NpcView>
    {
        private readonly List<NpcMediator> mediators = new();

        
        public NpcHandler(GameEntitySpawner<NpcMediator, NpcView> spawner) : base(spawner)
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
