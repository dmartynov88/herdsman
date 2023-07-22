using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace GameStates.Reset
{
    [CreateAssetMenu(fileName = "ResetGameStateInstaller", menuName = "Installers/GameStates/ResetGameStateInstaller")]
    public class ResetGameStateInstaller : ScriptableObjectInstaller
    {
        public override void Install(IInjectionContainer container)
        {
            container.Bind<ResetStateHandler>().ToSingleton();
            container.Bind<ResetGameState>().ToSingleton();
        }
    }
}