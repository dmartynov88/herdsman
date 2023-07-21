using System;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

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

        public async UniTask Initialize(TView view, SpawnData spawnData)
        {
            View = view;
            if (!View.HasGraphics)
            {
                //await Get object from addressables spawnData.name
                var viewObject = await LoadAsset(spawnData.AddressableName);
                viewObject.transform.localPosition = Vector3.zero;
                View.CacheViewObject(viewObject);
            }

            OnViewReady();
        }

        public void Destroy(out TView view)
        {
            OnDestroy();
            view = View;
        }
        
        protected async UniTask<GameObject> LoadAsset(string assetId)
        {
            if (string.IsNullOrEmpty(assetId))
            {
                throw new ArgumentNullException();
            }
            return await Addressables.InstantiateAsync(assetId, Vector3.zero, Quaternion.identity, View.Transform).Task;
        }

        //Subscribe to view events
        protected abstract void OnViewReady();

        //Unsubscribe from view events
        protected abstract void OnDestroy();
    }
}
