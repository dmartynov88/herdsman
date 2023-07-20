using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;

namespace Common.GameEntities.Handler
{
    public abstract class GameEntityHandlerBase<TMediator, TView> 
        where TMediator : IGameEntityMediator<TView>
        where TView : IGameEntityView
    {
        private readonly GameEntitySpawner<TMediator, TView> spawner;

        protected GameEntityHandlerBase(GameEntitySpawner<TMediator, TView> spawner)
        {
            this.spawner = spawner;
        }
        
        protected UniTask<TMediator> CreateMediator(SpawnData spawnData)
        {
            return spawner.CreateMediator(spawnData);
        }
    }
}