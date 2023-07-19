using System.Collections.Generic;
using System.Threading;
using Adic;
using Adic.Container;
using Cysharp.Threading.Tasks;
using Dependecies.Abstract;
using UnityEngine;

public class InitContext : ContextRoot
{
    [SerializeField] private MonoInstaller[] monoInstallers;
    [SerializeField] private ScriptableObjectInstaller[] soInstallers;

    private IInjectionContainer coreContainer;

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
        //IStatesService statesService = coreContainer.Resolve<IStatesService>();
        List<IBootInitializer> bootInitializers =
            coreContainer.GetExtension<BootInitializerContainerExtension>().BootInitializers;

        await UniTask.WhenAll(bootInitializers.Select(initializer => initializer.Initialize(cancellationToken)));

        //ToDo switch state to game
    }
}