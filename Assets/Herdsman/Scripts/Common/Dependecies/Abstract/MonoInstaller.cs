using Adic.Container;
using UnityEngine;

namespace Common.Dependecies.Abstract
{
    public abstract class MonoInstaller : MonoBehaviour, IContextInstaller
    {
        public abstract void Install(IInjectionContainer container);
    }
}