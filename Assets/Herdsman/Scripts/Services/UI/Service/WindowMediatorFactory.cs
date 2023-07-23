using System;
using Common.Dependecies.Abstract;
using Cysharp.Threading.Tasks;
using Common.UI.Abstract;
using Common.UI.Config;
using Services.UI.Windows.Game;
using Services.UI.Windows.Main;
using UnityEngine;

namespace Services.UI.Service
{
    public class WindowMediatorFactory : IWindowMediatorFactory
    {
        private readonly IContainerProvider containerProvider;
        private readonly IWindowsConfigDataProvider windowsConfigDataProvider;
        
        public WindowMediatorFactory(IContainerProvider containerProvider, IWindowsConfigDataProvider windowsConfigDataProvider)
        {
            this.containerProvider = containerProvider;
            this.windowsConfigDataProvider = windowsConfigDataProvider;
        }
        
        public async UniTask<IWindowMediator> CreateMediator(WindowType windowType, Transform root)
        {
            if (windowsConfigDataProvider.TryGetWindowsConfigData(windowType, out var config))
            {
                IWindowMediator result = windowType switch
                {
                    WindowType.MainMenu => containerProvider.Container.Resolve<MainWindowMediator>(),
                    WindowType.Game => containerProvider.Container.Resolve<GameWindowMediator>(),
                };

                await result.Initialize(config, root);
                return result;
            }
            
            
            throw new ArgumentException($"Can't find config for {windowType} window type!");
        }
    }
}