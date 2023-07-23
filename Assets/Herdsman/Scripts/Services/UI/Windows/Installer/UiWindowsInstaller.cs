using Adic.Container;
using Common.Dependecies.Abstract;
using UnityEngine;

namespace Services.UI.Windows.Installer
{
    [CreateAssetMenu(fileName = "UiWindowsInstaller", menuName = "Installers/UI/UiWindowsInstaller")]
    public class UiWindowsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ScriptableObjectInstaller[] windowsInstallers;
        
        public override void Install(IInjectionContainer container)
        {
            foreach (ScriptableObjectInstaller soInstaller in windowsInstallers)
            {
                soInstaller.Install(container);
            }
        }
    }
}