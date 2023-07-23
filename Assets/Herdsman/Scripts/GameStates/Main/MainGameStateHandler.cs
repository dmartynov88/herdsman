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
            uiShowParameters = new MainWindowShowParameters();
            uiShowParameters.StartGamePressed = SwitchToGame;
            
            await UiService.ShowWindow(WindowType.MainMenu, uiShowParameters);
        }

        private void SwitchToGame()
        {
            uiShowParameters.StartGamePressed = null;
            uiShowParameters = null;
            SwitchToGameUniTask().Forget();
        }

        private async UniTaskVoid SwitchToGameUniTask()
        {
            //Simple realization without windows queue and preloader, etc.
            UiService.HideWindow();
            GameStatesService.SwitchState((int)GameStateType.Game);
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
