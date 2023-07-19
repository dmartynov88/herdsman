using Cysharp.Threading.Tasks;

namespace GameEntities.Abstract
{
    public interface IGameEntityMediatorFactory<TMediator, TView> 
        where TMediator : IGameEntityMediator<TView>
        where TView : IGameEntityView
    {
        UniTask<TMediator> Create(TView view, SpawnData spawnData);
    }
}