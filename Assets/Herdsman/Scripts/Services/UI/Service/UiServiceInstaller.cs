﻿using Adic.Container;
using Common.Dependecies.Abstract;
using Common.UI.Abstract;
using Common.UI.Config;
using UnityEngine;

namespace Services.UI.Service
{
    public class UiServiceInstaller : MonoInstaller
    {
        [SerializeField] private UiService uiServiceInstance;
        [SerializeField] private UiConfigSo uiConfigSo;
        public override void Install(IInjectionContainer container)
        {
            container.Bind<IWindowsConfigDataProvider>().To(uiConfigSo);
            container.Bind<IWindowMediatorFactory>().ToSingleton<WindowMediatorFactory>();
            
            //Because of don't use [Inject] attribute to prevent dependency service on container
            uiServiceInstance.Initialize(container.Resolve<IWindowMediatorFactory>());
            DontDestroyOnLoad(uiServiceInstance.gameObject);
            
            container.Bind<UiService>().To(uiServiceInstance);
        }
    }
}