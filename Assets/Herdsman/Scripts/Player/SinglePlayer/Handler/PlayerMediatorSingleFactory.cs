using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using Player.SinglePlayer.Entity;

namespace Player.SinglePlayer
{
    public class PlayerMediatorSingleFactory : IGameEntityMediatorFactory<PlayerSingleMediator, PlayerSingleView> 
    {
        public async UniTask<PlayerSingleMediator> Create(uint entityId, PlayerSingleView singleView, SpawnData spawnData)
        {
            var mediator = new PlayerSingleMediator();
            await mediator.Initialize(singleView, spawnData);
            return mediator;
        }
    }
}