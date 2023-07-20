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
            container.Bind<IGameStatesService>().ToSingleton<GameStatesService>();
            
            foreach (ScriptableObjectInstaller soInstaller in statesInstallers)
            {
                soInstaller.Install(container);
            }

            container.Bind<GameStatesProvider>().ToSingleton();
            var statesService = container.Resolve<IGameStatesService>();
            
            statesService.Initialize(container.Resolve<GameStatesProvider>());

        }
    }
}