using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.UI.Abstract
{
    public interface IWindowMediatorFactory
    {
        UniTask<IWindowMediator> CreateMediator(WindowType windowType, Transform root);
    }
}