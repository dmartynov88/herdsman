using Adic.Container;

namespace Common.Dependecies.Abstract
{
    public interface IContainerProvider
    {
        public IInjectionContainer Container { get; }
    }

    public class ContainerProvider : IContainerProvider
    {
        public IInjectionContainer Container { get; private set; }

        public ContainerProvider(IInjectionContainer container)
        {
            Container = container;
        }
    }
}