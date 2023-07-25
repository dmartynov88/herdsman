using Adic.Container;
using Common.Dependecies.Abstract;
using Common.GameEntities.Spawner;
using NPC.AI;
using NPC.LocalMode.Entity;
using UnityEngine;

namespace NPC.SinglePlayer
{
    [CreateAssetMenu(fileName = "NpcSingleInstaller", menuName = "Installers/SinglePlayer/NpcSingleInstaller")]
    public class NpcSingleInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private NpcViewPool poolPrefab;
        [SerializeField] private AiConfigSo aiConfigSo;
        
        public override void Install(IInjectionContainer container)
        {
            var pool = Instantiate(poolPrefab);
            var factory = new NpcMediatorSingleFactory(aiConfigSo);
            var spawner = new GameEntitySpawner<NpcMediator, NpcView>(pool, factory);
            
            container.Bind<GameEntitySpawner<NpcMediator, NpcView>>().To(spawner).As("NPCSingleSpawner");
            container.Bind<NpcSingleHandler>().ToSingleton();
        }
    }
}