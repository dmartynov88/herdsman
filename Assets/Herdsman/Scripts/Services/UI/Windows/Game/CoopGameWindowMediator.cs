using Common.Assets.Abstract;
using Common.UI.Abstract;
using Cysharp.Threading.Tasks;
using Services.Player.Service;
using UnityEngine;

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
            View.RestartGameClicked += ViewOnRestartGameClicked;
            ResetScore();
            View.SetActive(true);
            return UniTask.CompletedTask;
        }

        private void ViewOnRestartGameClicked()
        {
            ResetScore();
            parameters.RestartGamePressed?.Invoke();
        }

        private void OnPlayerDataChanged()
        {
            Model.SetData(playerService.PlayerDataById[0].TotalScore, playerService.PlayerDataById[1].TotalScore);
        }

        protected override UniTask InitializeModel()
        {
            Model.SetData(playerService.PlayerDataById[0].TotalScore, playerService.PlayerDataById[1].TotalScore);
            return base.InitializeModel();
        }
        
        public override UniTask Hide()
        {
            ResetScore();
            View.SetActive(false);
            playerService.PlayerDataChanged -= OnPlayerDataChanged;
            View.RestartGameClicked -= ViewOnRestartGameClicked;
            return UniTask.CompletedTask;
        }

        private void ResetScore()
        {
            Model.SetData(0, 0);
            playerService.ResetScore();
        }
    }
}