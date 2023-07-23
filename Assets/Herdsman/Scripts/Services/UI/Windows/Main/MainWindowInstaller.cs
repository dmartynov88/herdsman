using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace Services.UI.Windows.Main
{
    [CreateAssetMenu(fileName = "MainWindowInstaller", menuName = "Installers/UI/MainWindowInstaller")]
    public class MainWindowInstaller : ScriptableObjectInstaller
    {
        public override void Install(IInjectionContainer container)
        {
            container.Bind<MainWindowMediator>().ToSingleton();
        }
    }
}