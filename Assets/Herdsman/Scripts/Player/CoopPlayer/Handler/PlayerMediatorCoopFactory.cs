using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using Player.CoopPlayer.Entity;
using Player.SinglePlayer.Entity;

namespace Player.CoopPlayer
{
    public class PlayerMediatorCoopFactory : IGameEntityMediatorFactory<PlayerCoopMediator, PlayerView> 
    {
        public async UniTask<PlayerCoopMediator> Create(uint entityId, PlayerView view, SpawnData spawnData)
        {
            var mediator = new PlayerCoopMediator();
            await mediator.Initialize(view, spawnData);
            return mediator;
        }
    }
}