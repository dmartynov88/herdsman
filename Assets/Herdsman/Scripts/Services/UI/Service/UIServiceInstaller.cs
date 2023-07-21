using Adic.Container;
using Common.Dependecies.Abstract;
using Herdsman.Scripts.Services.UI.Abstract;
using UnityEngine;

namespace Herdsman.Scripts.Services.UI.Service
{
    public class UIServiceInstaller : MonoInstaller
    {
        [SerializeField] private UIService uiServiceInstance;
        public override void Install(IInjectionContainer container)
        {
            container.Bind<IMediatorFactory>().ToSingleton<UIMediatorFactory>();
            DontDestroyOnLoad(uiServiceInstance.gameObject);
            container.Bind<UIService>().To(uiServiceInstance);
        }
    }
}