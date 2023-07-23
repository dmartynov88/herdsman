using Adic.Container;
using Common.Dependecies.Abstract;
using Services.Camera;
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
            //Because of don't use [Inject] attribute to prevent dependency service on container
            inputService.Initialize(container.Resolve<CameraService>());
            DontDestroyOnLoad(inputService.gameObject);
            container.Bind<InputService>().To(inputService);
        }
    }
}
