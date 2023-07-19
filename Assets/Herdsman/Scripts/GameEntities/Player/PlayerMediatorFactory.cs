using Cysharp.Threading.Tasks;
using GameEntities.Abstract;

namespace GameEntities.Player
{
    //For example we can create two factories for local and network player
    public class PlayerMediatorFactory : IGameEntityMediatorFactory<PlayerMediator, PlayerView> 
    {
        public async UniTask<PlayerMediator> Create(PlayerView view, SpawnData spawnData)
        {
            var mediator = new PlayerMediator();
            await mediator.Initialize(view, spawnData);
            return mediator;
        }
    }
}