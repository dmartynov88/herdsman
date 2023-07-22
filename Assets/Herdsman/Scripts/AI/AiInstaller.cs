using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "AiInstaller", menuName = "Installers/AiInstaller")]
    public class AiInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private AiConfigSo aiConfigSo;
        
        public override void Install(IInjectionContainer container)
        {
            container.Bind<IAiMovementDataProvider>().To(aiConfigSo);
            container.Bind<AiSystem>().ToSingleton();
        }
    }
}