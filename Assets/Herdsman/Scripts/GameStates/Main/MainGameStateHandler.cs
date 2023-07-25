using Adic;
using Common.States.Abstract;
using Cysharp.Threading.Tasks;
using Services.UI.Service;
using GameStates.Abstract;
using Common.UI.Config;
using Services.UI.Windows.Main;

namespace GameStates.Main
{
    public class MainGameStateHandler : IGameStateHandler
    {
        [Inject] private UiService UiService { get; set; }
        [Inject] private IGameStatesService GameStatesService { get; set; }

        private MainWindowShowParameters uiShowParameters;


        //ToDo implement cancellation tokens (loading errors, connection errors after implement network)
        
        public void Start()
        {
            InitState().Forget();
        }

        private async UniTaskVoid InitState()
        {
            //Simple realization
            uiShowParameters = new MainWindowShowParameters
            {
                StartSingleGamePressed = SwitchToSingleGame,
                StartCoopGamePressed = SwitchToCoopGame
            };

            await UiService.ShowWindow(WindowType.MainMenu, uiShowParameters);
        }

        private void SwitchToSingleGame()
        {
            uiShowParameters.StartSingleGamePressed = null;
            uiShowParameters.StartCoopGamePressed = null;
            uiShowParameters = null;
            SwitchToSingleGameUniTask().Forget();
        }

        private async UniTaskVoid SwitchToSingleGameUniTask()
        {
            await UiService.HideWindow();
            GameStatesService.SwitchState((int)GameStateType.SingleGame);
        }
        
        private void SwitchToCoopGame()
        {
            uiShowParameters.StartSingleGamePressed = null;
            uiShowParameters.StartCoopGamePressed = null;
            uiShowParameters = null;
            SwitchToCoopGameUniTask().Forget();
        }
        
        private async UniTaskVoid SwitchToCoopGameUniTask()
        {
            await UiService.HideWindow();
            GameStatesService.SwitchState((int)GameStateType.CoopGame);
        }

        public UniTask Finish()
        {
            return UniTask.CompletedTask;
        }

        public void Dispose()
        {
        }
    }
}
