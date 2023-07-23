using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Services.UI.Abstract
{
    public interface IWindowMediator
    {
        WindowType WindowType { get; }
        UniTask Initialize(UIWindowConfig config, Transform root);
    }

    public abstract class WindowMediatorBase<TView> : IWindowMediator
    where TView : WindowViewBase
    {
        public  WindowType WindowType { get; private set; }
        protected TView View { get; private set; }

        public UniTask Initialize(UIWindowConfig config, Transform root)
        {
            WindowType = config.WindowType;
            return LoadAsset(config.WindowPrefabName, root);
        }
        
        private async UniTask LoadAsset(string addressableName, Transform root)
        {
            
            if (string.IsNullOrEmpty(addressableName))
            {
                throw new ArgumentNullException();
            }

            var viewObject = await Addressables.InstantiateAsync(addressableName, Vector3.zero, Quaternion.identity, root).Task;
            View = viewObject.GetComponent<TView>();
            await View.InitializeView();
            
        }

        protected abstract void OnViewReady();
    }
}