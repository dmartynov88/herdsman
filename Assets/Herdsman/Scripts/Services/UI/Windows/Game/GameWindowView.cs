using Cysharp.Threading.Tasks;
using Common.UI.Abstract;

namespace Services.UI.Windows.Game
{
    public class GameWindowView : WindowViewBase<GameWindowModel>
    {
        public override UniTask InitializeView(GameWindowModel model)
        {
            return UniTask.CompletedTask;
        }
    }
}