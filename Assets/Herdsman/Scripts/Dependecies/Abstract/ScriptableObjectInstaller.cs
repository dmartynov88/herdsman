using Adic.Container;
using UnityEngine;

namespace Dependecies.Abstract
{
    public abstract class ScriptableObjectInstaller : ScriptableObject, IContextInstaller
    {
        public abstract void Install(IInjectionContainer container);
    }
}