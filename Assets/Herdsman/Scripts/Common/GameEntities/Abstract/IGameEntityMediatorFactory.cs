using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;

namespace Common.GameEntities.Abstract
{
    public interface IGameEntityMediatorFactory<TMediator, TView> 
        where TMediator : IGameEntityMediator<TView>
        where TView : IGameEntityView
    {
        UniTask<TMediator> Create(uint entityId, TView view, SpawnData spawnData);
    }

    public class GameEntityMediatorFactory<TMediator, TView> : IGameEntityMediatorFactory<TMediator, TView> 
        where TMediator : IGameEntityMediator<TView>, new()
        where TView : IGameEntityView
    {
        public async UniTask<TMediator> Create(uint entityId, TView view, SpawnData spawnData)
        {
            var mediator = new TMediator();
            await mediator.Initialize(entityId, view, spawnData);
            return mediator;
        }
    }
}