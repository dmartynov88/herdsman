using Cysharp.Threading.Tasks;

namespace GameEntities.Abstract
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


        public UniTask CreateMediator(SpawnData data)
        {
            
            return UniTask.CompletedTask;
        }
    }
}