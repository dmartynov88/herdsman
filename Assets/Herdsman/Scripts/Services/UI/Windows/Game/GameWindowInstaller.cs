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
            container.Bind<GameWindowMediator>().ToSingleton();
        }
    }
}