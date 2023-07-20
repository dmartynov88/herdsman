using Adic.Container;
using UnityEngine;

namespace Common.Dependecies.Abstract
{
    public abstract class ScriptableObjectInstaller : ScriptableObject, IContextInstaller
    {
        public abstract void Install(IInjectionContainer container);
    }
}