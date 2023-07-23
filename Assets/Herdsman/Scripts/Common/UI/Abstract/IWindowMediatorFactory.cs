using Common.UI.Config;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.UI.Abstract
{
    public interface IWindowMediatorFactory
    {
        UniTask<IWindowMediator> CreateMediator(WindowType windowType, Transform root);
    }
}