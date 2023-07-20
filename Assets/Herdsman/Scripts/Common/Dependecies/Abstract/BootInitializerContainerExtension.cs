using System.Collections.Generic;
using System.Linq;
using Adic.Binding;
using Adic.Container;

namespace Common.Dependecies.Abstract
{
    public class BootInitializerContainerExtension : IContainerExtension
    {
        public List<IBootInitializer> BootInitializers { get; }

        public BootInitializerContainerExtension()
        {
            BootInitializers = new List<IBootInitializer>();
        }

        public void Init(IInjectionContainer container)
        {
            //empty
        }

        public void OnRegister(IInjectionContainer container)
        {
            container.afterAddBinding += OnAfterAddBinding;
        }

        public void OnUnregister(IInjectionContainer container)
        {
            container.afterAddBinding -= OnAfterAddBinding;

            BootInitializers.Clear();
        }

        private void OnAfterAddBinding(IBinder source, ref BindingInfo binding)
        {
            if (binding.instanceType != BindingInstance.Singleton ||
                binding.value is not IBootInitializer bootInitializer ||
                BootInitializers.Contains(binding.value))
            {
                return;
            }

            BootInitializers.Add(bootInitializer);
        }
    }
}