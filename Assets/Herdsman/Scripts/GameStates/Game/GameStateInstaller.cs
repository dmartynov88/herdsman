using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace GameStates.Game
{
    [CreateAssetMenu(fileName = "GameStateInstaller", menuName = "Installers/GameStateInstaller")]
    public class GameStateInstaller : ScriptableObjectInstaller
    {
        public override void Install(IInjectionContainer container)
        {
            container.Bind<GameStateHandler>().To(new GameStateHandler());
        }
    }
}