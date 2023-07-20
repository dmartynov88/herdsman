using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;

namespace Common.GameEntities.Abstract
{
    public interface IGameEntityMediator<TView>
        where TView : IGameEntityView
    {
        UniTask Initialize(TView view, SpawnData spawnData);
        void Destroy(out TView view);
    }

    public abstract class GameEntityMediatorBase<TView> : IGameEntityMediator<TView>
        where TView : IGameEntityView
    {
        protected TView View { get; private set; }

        public UniTask Initialize(TView view, SpawnData spawnData)
        {
            View = view;
            if (!View.HasGraphics)
            {
                //await Get object from addressables spawnData.name
            }

            OnViewReady();
            return UniTask.CompletedTask;
        }

        public void Destroy(out TView view)
        {
            OnDestroy();
            view = View;
        }

        //Subscribe to view events
        protected abstract void OnViewReady();

        //Unsubscribe from view events
        protected abstract void OnDestroy();
    }
}
