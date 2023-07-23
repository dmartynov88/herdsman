using Adic.Container;
using Common.Dependecies.Abstract;
using Services.UI.Abstract;
using Services.UI.Service;
using UnityEngine;

namespace ervices.UI.Service
{
    public class UiServiceInstaller : MonoInstaller
    {
        [SerializeField] private UiService uiServiceInstance;
        [SerializeField] private UiConfigSo uiConfigSo;
        public override void Install(IInjectionContainer container)
        {
            container.Bind<IWindowsConfigDataProvider>().To(uiConfigSo);
            container.Bind<IWindowMediatorFactory>().ToSingleton<WindowMediatorFactory>();
            DontDestroyOnLoad(uiServiceInstance.gameObject);
            container.Bind<UiService>().To(uiServiceInstance);
        }
    }
}