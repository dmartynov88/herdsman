using Common.Dependecies.Abstract;
using Common.States.Abstract;
using Cysharp.Threading.Tasks;
using GameStates.Abstract;

namespace Context
{
    public class MainContext : BootContext
    {
        protected override void OnContextInitialized()
        {
            IGameStatesService statesService = coreContainer.Resolve<IGameStatesService>();
            statesService.SwitchState((int)GameStateType.Main).Forget();
        }
    }
}