using Cysharp.Threading.Tasks;
using GameEntities.Models;

namespace GameEntities.Abstract
{
    public interface IGameEntityMediatorFactory<TMediator, TView> 
        where TMediator : IGameEntityMediator<TView>
        where TView : IGameEntityView
    {
        UniTask<TMediator> Create(TView view, SpawnData spawnData);
    }

    public class GameEntityMediatorFactory<TMediator, TView> : IGameEntityMediatorFactory<TMediator, TView> 
        where TMediator : IGameEntityMediator<TView>, new()
        where TView : IGameEntityView
    {
        public async UniTask<TMediator> Create(TView view, SpawnData spawnData)
        {
            var mediator = new TMediator();
            await mediator.Initialize(view, spawnData);
            return mediator;
        }
    }
}