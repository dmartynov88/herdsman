using Common.Assets.Abstract;
using Cysharp.Threading.Tasks;
using Common.UI.Abstract;
using Services.Player.Service;

namespace Services.UI.Windows.Game
{
    public class GameWindowMediator: WindowMediatorBase<GameWindowView, GameWindowModel>
    {
        private readonly PlayerService playerService;
        private GameWindowShowParameters parameters;
        
        public GameWindowMediator(PlayerService playerService, IAssetService assetService) : base(assetService)
        {
            this.playerService = playerService;
        }

        public override UniTask Show(IWindowShowParameters parameters = null)
        {
            this.parameters = parameters as GameWindowShowParameters;
            playerService.PlayerDataChanged += OnPlayerDataChanged;
            Model.SetData(playerService.PlayerData);
            View.SetActive(true);
            Subscribe();
            return UniTask.CompletedTask;
        }

        private void OnPlayerDataChanged()
        {
            Model.SetData(playerService.PlayerData);
        }

        public override UniTask Hide()
        {
            Unsubscribe();
            View.SetActive(false);
            playerService.PlayerDataChanged -= OnPlayerDataChanged;
            return UniTask.CompletedTask;
        }

        protected override UniTask InitializeModel()
        {
            Model.SetData(playerService.PlayerData);
            return base.InitializeModel();
        }

        public override void Dispose()
        {
            base.Dispose();
            playerService.PlayerDataChanged -= OnPlayerDataChanged;
        }
        
        private void Subscribe()
        {
            View.RestartGameClicked += OnRestartGameClicked;
        }

        private void Unsubscribe()
        {
            View.RestartGameClicked -= OnRestartGameClicked;
        }
        
        private void OnRestartGameClicked()
        {
            parameters.RestartGamePressed?.Invoke();
        }
    }
}
