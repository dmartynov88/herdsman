using System;
using Common.Dependecies.Abstract;
using Common.States.Abstract;
using Cysharp.Threading.Tasks;
using GameStates.Abstract;

namespace Context
{
    public class MainContext : BootContext
    {
        private IGameStatesService statesService;
        
        protected override void OnContextInitialized()
        {
            statesService = coreContainer.Resolve<IGameStatesService>();
            statesService.SwitchState((int)GameStateType.Main).Forget();
        }

        private void OnApplicationQuit()
        {
            statesService.Dispose();
        }
    }
}