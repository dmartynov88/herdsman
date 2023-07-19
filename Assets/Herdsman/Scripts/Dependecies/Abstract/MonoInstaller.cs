using Adic.Container;
using UnityEngine;

namespace Dependecies.Abstract
{
    public abstract class MonoInstaller : MonoBehaviour, IContextInstaller
    {
        public abstract void Install(IInjectionContainer container);
    }
}