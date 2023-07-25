using Common.Assets.Abstract;
using Common.UI.Abstract;
using Cysharp.Threading.Tasks;
using Services.Player.Service;

namespace Services.UI.Windows.Game
{
    public class CoopGameWindowMediator : WindowMediatorBase<GameCoopWindowView, CoopGameWindowModel>
    {
        private readonly CoopPlayerService playerService;
        private GameWindowShowParameters parameters;
        
        public CoopGameWindowMediator(CoopPlayerService playerService, IAssetService assetService) : base(assetService)
        {
            this.playerService = playerService;
        }

        public override UniTask Show(IWindowShowParameters parameters = null)
        {
            this.parameters = parameters as GameWindowShowParameters;
            playerService.PlayerDataChanged += OnPlayerDataChanged;
            Model.SetData(0, 0);
            View.SetActive(true);
            return UniTask.CompletedTask;
        }

        private void OnPlayerDataChanged()
        {
            Model.SetData(playerService.PlayerDataById[0].TotalScore, playerService.PlayerDataById[1].TotalScore);
        }

        public override UniTask Hide()
        {
            playerService.PlayerDataChanged -= OnPlayerDataChanged;
            return UniTask.CompletedTask;
        }
    }
}