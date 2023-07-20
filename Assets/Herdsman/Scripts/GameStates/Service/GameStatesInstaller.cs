using Adic.Container;
using Common.Dependecies.Abstract;
using Common.States.Abstract;
using UnityEngine;

namespace GameStates.Service
{
    [CreateAssetMenu(fileName = "GameStatesInstaller", menuName = "Installers/GameStatesInstaller")]
    public class GameStatesInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ScriptableObjectInstaller[] statesInstallers;
        
        public override void Install(IInjectionContainer container)
        {
            foreach (ScriptableObjectInstaller soInstaller in statesInstallers)
            {
                soInstaller.Install(container);
            }
            
            container.Bind<IGameStatesService>().ToSingleton<GameStatesService>();
        }
    }
}