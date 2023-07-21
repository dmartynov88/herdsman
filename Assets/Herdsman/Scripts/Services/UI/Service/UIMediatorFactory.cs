using Common.Dependecies.Abstract;
using Cysharp.Threading.Tasks;

namespace Herdsman.Scripts.Services.UI.Abstract
{
    public class UIMediatorFactory : IMediatorFactory
    {
        private readonly IContainerProvider containerProvider;
        
        public UIMediatorFactory(IContainerProvider containerProvider)
        {
            this.containerProvider = containerProvider;
        }
        
        public async UniTask<TMediator> CreateMediator<TMediator, TView>(UIWindowConfig config) 
            where TMediator : IMediator<TView> 
            where TView : IView
        {
            //ToDo await create by container
            return default(TMediator);
        }
    }
}