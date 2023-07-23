using Cysharp.Threading.Tasks;
using Services.UI.Abstract;

namespace Services.UI.Windows.Main
{
    public class MainWindowView : WindowViewBase
    {
        public override UniTask InitializeView()
        {
            return UniTask.CompletedTask;
        }
    }
}