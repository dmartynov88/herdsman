using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace Herdsman.Scripts.GameStates.Reset
{
    [CreateAssetMenu(fileName = "ResetGameStateInstaller", menuName = "Installers/ResetGameStateInstaller")]
    public class ResetGameStateInstaller : ScriptableObjectInstaller
    {
        public override void Install(IInjectionContainer container)
        {
            container.Bind<ResetStateHandler>().To(new ResetStateHandler());
        }
    }
}