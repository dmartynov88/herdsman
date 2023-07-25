using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace Services.UI.Windows.Game
{
    [CreateAssetMenu(fileName = "GameWindowInstaller", menuName = "Installers/UI/GameWindowInstaller")]
    public class GameWindowInstaller : ScriptableObjectInstaller
    {
        public override void Install(IInjectionContainer container)
        {
            //Bind dependencies and create mediator with container for auto resolve on creation
            //Dependencies add to ctor for prevent dependency mediator on container (don't use [Inject] inside mediator)
            container.Bind<GameWindowMediator>().ToSingleton();
            container.Bind<CoopGameWindowMediator>().ToSingleton();
        }
    }
}