using System;
using System.Threading;
using Common.Assets.Abstract;
using Common.UI.Config;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Common.UI.Abstract
{
    public interface IWindowShowParameters
    {
    }

    public interface IWindowMediator
    {
        WindowType WindowType { get; }
        UniTask Initialize(UIWindowConfig config, Transform root);

        UniTask Show(IWindowShowParameters parameters = null);
        UniTask Hide();
    }

    public abstract class WindowMediatorBase<TView, TModel> : IWindowMediator, IAssetContext
    where TView : WindowViewBase<TModel>
    where TModel : IWindowModel, new()
    {
        protected WindowMediatorBase(IAssetService assetService)
        {
            this.assetService = assetService;
        }

        public  WindowType WindowType { get; private set; }
        protected TView View { get; private set; }
        protected TModel Model { get; private set; }

        private readonly IAssetService assetService;

        public async UniTask Initialize(UIWindowConfig config, Transform root)
        {
            WindowType = config.WindowType;
            Model = new TModel();
            await InitializeModel();
            await LoadAsset(config.WindowPrefabName, root);
        }


        public abstract UniTask Show(IWindowShowParameters parameters = null);
        public abstract UniTask Hide();
        protected abstract UniTask InitializeModel();
        protected abstract void OnViewReady();
        

        private async UniTask LoadAsset(string addressableName, Transform root)
        {
            if (string.IsNullOrEmpty(addressableName))
            {
                throw new ArgumentNullException();
            }
            var viewAsset = await assetService.LoadComponentAsync<Component>(addressableName, this, new CancellationToken());
            View = Object.Instantiate(viewAsset, root).GetComponent<TView>();
            await View.InitializeView(Model);
        }
    }
}