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
}