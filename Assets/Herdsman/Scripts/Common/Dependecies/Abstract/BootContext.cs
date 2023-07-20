using System.Collections.Generic;
using System.Threading;
using Adic;
using Adic.Container;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Dependecies.Abstract
{
    public abstract class BootContext : ContextRoot
    {
        [SerializeField] private MonoInstaller[] monoInstallers;
        [SerializeField] private ScriptableObjectInstaller[] soInstallers;

        protected IInjectionContainer coreContainer;

        public override void SetupContainers()
        {
            coreContainer = AddContainer<InjectionContainer>()
                .RegisterExtension<EventCallerContainerExtension>()
                .RegisterExtension<UnityBindingContainerExtension>()
                .RegisterExtension<BootInitializerContainerExtension>();

            foreach (MonoInstaller monoInstaller in monoInstallers)
            {
                monoInstaller.Install(coreContainer);
            }

            foreach (ScriptableObjectInstaller soInstaller in soInstallers)
            {
                soInstaller.Install(coreContainer);
            }

            coreContainer.Bind<IBootInitializer[]>().Lazy();
        }


        public override void Init()
        {
            this.Inject();
            CancellationToken cancellationToken = this.GetCancellationTokenOnDestroy();

            Initialize(cancellationToken).Forget();
        }

        private async UniTaskVoid Initialize(CancellationToken cancellationToken)
        {
            List<IBootInitializer> bootInitializers =
                coreContainer.GetExtension<BootInitializerContainerExtension>().BootInitializers;

            await UniTask.WhenAll(bootInitializers.Select(initializer => initializer.Initialize(cancellationToken)));

            OnContextInitialized();
        }

        protected abstract void OnContextInitialized();
    }
}