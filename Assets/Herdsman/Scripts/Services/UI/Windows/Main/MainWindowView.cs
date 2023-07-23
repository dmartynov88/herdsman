using Cysharp.Threading.Tasks;
using Common.UI.Abstract;

namespace Services.UI.Windows.Main
{
    public class MainWindowView : WindowViewBase<MainWindowModel>
    {
        public override UniTask InitializeView(MainWindowModel model)
        {
            return UniTask.CompletedTask;
        }
    }
}