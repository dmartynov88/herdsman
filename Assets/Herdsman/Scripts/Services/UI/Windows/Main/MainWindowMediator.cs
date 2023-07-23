using System;
using Common.Assets.Abstract;
using Cysharp.Threading.Tasks;
using Common.UI.Abstract;

namespace Services.UI.Windows.Main
{
    public class MainWindowMediator : WindowMediatorBase<MainWindowView, MainWindowModel>
    {
        private MainWindowShowParameters parameters;

        public MainWindowMediator(IAssetService assetService) : base(assetService)
        {
        }

        public override UniTask Show(IWindowShowParameters parameters = null)
        {
            if (parameters != null)
            {
                this.parameters = parameters as MainWindowShowParameters;
            }
            
            View.SetActive(true);
            
            Subscribe();
            
            return UniTask.CompletedTask;
        }

        public override UniTask Hide()
        {
            View.SetActive(false);
            
            Unsubscribe();
            
            return UniTask.CompletedTask;
        }

        private void Subscribe()
        {
            View.StarnGameClicked += OnStarnGameClicked;
        }

        private void Unsubscribe()
        {
            View.StarnGameClicked -= OnStarnGameClicked;
        }

        private void OnStarnGameClicked()
        {
            parameters.StartGamePressed?.Invoke();
        }
    }
}