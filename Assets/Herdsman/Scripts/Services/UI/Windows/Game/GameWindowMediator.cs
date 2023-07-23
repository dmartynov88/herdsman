using Common.Assets.Abstract;
using Cysharp.Threading.Tasks;
using Common.UI.Abstract;

namespace Services.UI.Windows.Game
{
    public class GameWindowMediator: WindowMediatorBase<GameWindowView, GameWindowModel>
    {
        public GameWindowMediator(IAssetService assetService) : base(assetService)
        {
        }

        public override UniTask Show(IWindowShowParameters parameters = null)
        {
            return UniTask.CompletedTask;
        }

        public override UniTask Hide()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask InitializeModel()
        {
            return UniTask.CompletedTask;
        }

        protected override void OnViewReady()
        {
            
        }
    }
}
