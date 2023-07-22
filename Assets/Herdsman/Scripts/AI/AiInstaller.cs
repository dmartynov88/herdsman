using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "AiInstaller", menuName = "Installers/AiInstaller")]
    public class AiInstaller : ScriptableObjectInstaller
    {
        public override void Install(IInjectionContainer container)
        {
            container.Bind<AiSystem>().ToSingleton();
        }
    }
}