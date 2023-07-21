using Cysharp.Threading.Tasks;

namespace Herdsman.Scripts.Services.UI.Abstract
{
    public interface IMediatorFactory
    {
        UniTask<TMediator> CreateMediator<TMediator, TView>(UIWindowConfig config) 
            where TMediator : IMediator<TView> 
            where TView : IView;
    }
}