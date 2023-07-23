using Cysharp.Threading.Tasks;
using Services.UI.Abstract;

namespace Services.UI.Windows.Game
{
    public class GameVindowView : WindowViewBase
    {
        public override UniTask InitializeView()
        {
            return UniTask.CompletedTask;
        }
    }
}