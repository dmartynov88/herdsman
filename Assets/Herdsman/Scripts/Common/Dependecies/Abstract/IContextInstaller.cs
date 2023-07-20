using Adic.Container;

namespace Common.Dependecies.Abstract
{
    public interface IContextInstaller
    {
        void Install(IInjectionContainer container);
    }
}