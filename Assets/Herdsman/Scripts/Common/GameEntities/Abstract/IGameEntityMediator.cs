using System;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Common.GameEntities.Abstract
{
    public interface IGameEntityMediator
    {
        uint EntityId { get; }
    }

    public interface IGameEntityMediator<TView> : IGameEntityMediator
        where TView : IGameEntityView
    {
        //UniTask Initialize(uint entityId, TView view, SpawnData spawnData);
        void Destroy(out TView view);
    }

    public abstract class GameEntityMediatorBase<TView> : IGameEntityMediator<TView>
        where TView : IGameEntityView
    {
        public uint EntityId { get; private set; }
        protected TView View { get; private set; }

        protected virtual async UniTask Initialize(uint entityId, TView view, SpawnData spawnData)
        {
            View = view;
            EntityId = entityId;

#if !AUTHORITY_SERVER
            await LoadAsset(spawnData.AddressableName);
#endif
            View.InitializeView();
            OnViewReady();
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
        
        private async UniTask LoadAsset(string addressableName)
        {
            if (!View.HasGraphics)
            {
                if (string.IsNullOrEmpty(addressableName))
                {
                    throw new ArgumentNullException();
                }

                var viewObject = await Addressables.InstantiateAsync(addressableName, Vector3.zero, Quaternion.identity, View.Transform).Task;
                viewObject.transform.localPosition = Vector3.zero;
                View.CacheViewObject(viewObject);
            }
        }
    }
}
