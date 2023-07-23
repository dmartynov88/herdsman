using Adic.Container;
using Common.Dependecies.Abstract;
using Common.GameEntities.Abstract;
using Common.GameEntities.Spawner;
using NPC.AI;
using NPC.SinglePlayer.Entity;
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
            var spawner = new GameEntitySpawner<NpcSingleMediator, NpcSingleView>(pool, factory);
            
            container.Bind<GameEntitySpawner<NpcSingleMediator, NpcSingleView>>().To(spawner);
            container.Bind<NpcSingleHandler>().ToSingleton();
        }
    }
}