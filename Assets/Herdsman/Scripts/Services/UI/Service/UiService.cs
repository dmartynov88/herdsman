using System.Collections.Generic;
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

        private readonly Dictionary<WindowType, IWindowMediator> windowsCache = new();

        public void Initialize(IWindowMediatorFactory mediatorFactory)
        {
            this.mediatorFactory = mediatorFactory;
        }

        //Possible mismatch specific showParameters and mediator type! rewrite to save inattentive colleagues from suicide (if want)
        public async UniTask<IWindowMediator> ShowWindow(WindowType windowType, IWindowShowParameters parameters = null)
        {
            if (!windowsCache.ContainsKey(windowType))
            {
                var result = await mediatorFactory.CreateMediator(windowType, windowsRoot);
                windowsCache.Add(windowType, result);
            }
            await windowsCache[windowType].Show(parameters);
            currentOpenedWindow = windowsCache[windowType];
            return windowsCache[windowType];
        }

        //ToDo add windows anim states and other logic
        public async UniTask HideWindow()
        {
            if (currentOpenedWindow != null)
            {
                await currentOpenedWindow.Hide();
            }
        }
    }
}