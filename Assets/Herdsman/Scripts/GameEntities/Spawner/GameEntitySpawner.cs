using Cysharp.Threading.Tasks;
using GameEntities.Abstract;
using GameEntities.Models;
using GameEntities.Pool;

namespace GameEntities.Spawner
{
    public class GameEntitySpawner<TMediator, TView>
        where TMediator : IGameEntityMediator<TView>
        where TView : IGameEntityView
    {
        private readonly ViewPool<TView> viewPool;
        private readonly IGameEntityMediatorFactory<TMediator, TView> mediatorFactory;


        public GameEntitySpawner(ViewPool<TView> viewPool, IGameEntityMediatorFactory<TMediator, TView> mediatorFactory)
        {
            this.viewPool = viewPool;
            this.mediatorFactory = mediatorFactory;
        }


        public UniTask<TMediator> CreateMediator(SpawnData data)
        {
            TView entityViewContainer = viewPool.Get(data.Position);
            return mediatorFactory.Create(entityViewContainer, data);
        }

        public void DestroyMediator(TMediator mediator)
        {
            mediator.Destroy(out TView view);
            viewPool.ReturnToPool(view);
        }

    }
}
