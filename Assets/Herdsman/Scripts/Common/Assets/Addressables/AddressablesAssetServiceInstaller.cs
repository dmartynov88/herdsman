using Adic.Container;
using Common.Assets.Abstract;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace Common.Assets.Addressables.Installers
{
    [CreateAssetMenu(fileName = "AddressablesAssetServiceInstaller",
        menuName = "Installers/AddressablesAssetServiceInstaller")]
    public class AddressablesAssetServiceInstaller : ScriptableObjectInstaller
    {
        public override void Install(IInjectionContainer container)
        {
            container.Bind<IAssetService>().ToSingleton<AddressablesAssetService>();
            container.Bind<AddressablesAssetServiceInitializer>().ToSingleton();
            
        }
    }
}