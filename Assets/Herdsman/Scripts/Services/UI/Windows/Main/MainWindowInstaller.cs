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
            //Bind dependencies and create mediator with container for auto resolve on creation
            //Dependencies add to ctor for prevent dependency mediator on container (don't use [Inject] inside mediator)
            container.Bind<MainWindowMediator>().ToSingleton();
        }
    }
}