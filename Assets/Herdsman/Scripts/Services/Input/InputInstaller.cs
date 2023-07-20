using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace Services.InputSystem
{
    [CreateAssetMenu(fileName = "InputInstaller", menuName = "Installers/InputInstaller")]
    public class InputInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private InputService inputServicePrefab;
        
        public override void Install(IInjectionContainer container)
        {
            var inputService = Instantiate(inputServicePrefab);
            DontDestroyOnLoad(inputService.gameObject);
            container.Bind<InputService>().To(inputService);
        }
    }
}
