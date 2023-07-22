using Adic.Container;
using Common.Dependecies.Abstract;
using Common.GameEntities.Abstract;
using Common.GameEntities.Spawner;
using NPC.Entity;
using UnityEngine;

namespace NPC.SinglePlayer
{
    [CreateAssetMenu(fileName = "NpcSingleInstaller", menuName = "Installers/SinglePlayer/NpcSingleInstaller")]
    public class NpcSingleInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private NpcViewPool poolPrefab;
        
        public override void Install(IInjectionContainer container)
        {
            var pool = Instantiate(poolPrefab);
            var factory = new GameEntityMediatorFactory<NpcMediator, NpcView>();
            var spawner = new GameEntitySpawner<NpcMediator, NpcView>(pool, factory);
            var handler = new NpcSingleHandler(spawner);
            container.Bind<NpcSingleHandler>().To(handler);
        }
    }
}