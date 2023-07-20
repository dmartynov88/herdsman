using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace Services.Camera
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CameraService inputServicePrefab;
        public override void Install(IInjectionContainer container)
        {
            DontDestroyOnLoad(inputServicePrefab.gameObject);
            container.Bind<CameraService>().To(inputServicePrefab);
        }
    }
}
