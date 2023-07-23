using Cysharp.Threading.Tasks;
using Common.UI.Abstract;
using Common.UI.Config;
using UnityEngine;

namespace Services.UI.Service
{
    public class UiService : MonoBehaviour
    {
        [SerializeField] private Transform windowsRoot;
        private IWindowMediatorFactory mediatorFactory;
        private IWindowMediator currentOpenedWindow;

        public void Initialize(IWindowMediatorFactory mediatorFactory)
        {
            this.mediatorFactory = mediatorFactory;
        }

        //Possible mismatch specific showParameters and mediator type! rewrite to save inattentive colleagues from suicide (if want)
        public async UniTask<IWindowMediator> ShowWindow(WindowType windowType, IWindowShowParameters parameters = null)
        {
            var result = await mediatorFactory.CreateMediator(windowType, windowsRoot);
            await result.Show(parameters);
            return result;
        }

        //ToDo add windows anim states and other logic
        public UniTask HideWindow()
        {
            if (currentOpenedWindow != null)
            {
                return currentOpenedWindow.Hide();
            }
            return UniTask.CompletedTask;
        }
    }
}