using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using Player.SinglePlayer.Entity;

namespace Player.SinglePlayer
{
    public class PlayerMediatorSingleFactory : IGameEntityMediatorFactory<PlayerSingleMediator, PlayerView> 
    {
        public async UniTask<PlayerSingleMediator> Create(uint entityId, PlayerView view, SpawnData spawnData)
        {
            var mediator = new PlayerSingleMediator();
            await mediator.Initialize(view, spawnData);
            return mediator;
        }
    }
}