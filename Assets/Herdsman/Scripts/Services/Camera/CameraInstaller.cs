using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace Services.Camera
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CameraService cameraServiceInstance;
        public override void Install(IInjectionContainer container)
        {
            DontDestroyOnLoad(cameraServiceInstance.gameObject);
            container.Bind<CameraService>().To(cameraServiceInstance);
        }
    }
}
