using System.Collections.Generic;
using Adic;
using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using NPC.LocalMode.Entity;
using Services.Player.Service;

namespace NPC.SinglePlayer
{
    public class NpcSingleHandler : GameEntityHandlerBase<NpcMediator, NpcView>
    {
        private readonly List<NpcMediator> mediators = new();
        private readonly PlayerService playerService;
        
        public NpcSingleHandler(PlayerService playerService, GameEntitySpawner<NpcMediator, NpcView> spawner) : base(spawner)
        {
            this.playerService = playerService;
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
            mediator.ReachedYard += OnReachedYard;
        }

        private void UnsubscribeFromMediatorEvents(NpcMediator mediator)
        {
            mediator.ReachedYard -= OnReachedYard;
        }

        private void OnReachedYard(int yardId)
        {
            playerService.AddScore();
        }
    }
}
