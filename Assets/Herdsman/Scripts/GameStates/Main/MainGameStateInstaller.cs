using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace GameStates.Main
{
    [CreateAssetMenu(fileName = "MainGameStateInstaller", menuName = "Installers/MainGameStateInstaller")]
    public class MainGameStateInstaller : ScriptableObjectInstaller
    {
        public override void Install(IInjectionContainer container)
        {
            container.Bind<MainGameStateHandler>().ToSingleton();
            container.Bind<MainGameState>().ToSingleton();
        }
    }
}