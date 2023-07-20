using Adic.Container;
using Dependecies.Abstract;
using GameEntities.Abstract;
using GameEntities.Spawner;
using Player.Entity;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerInstaller", menuName = "Installers/PlayerInstaller")]
    public class PlayerInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerViewPool poolPrefab;

        public override void Install(IInjectionContainer container)
        {
            var pool = Instantiate(poolPrefab);
            var factory = new GameEntityMediatorFactory<PlayerMediator, PlayerView>();
            var spawner = new GameEntitySpawner<PlayerMediator, PlayerView>(pool, factory);
            var handler = new PlayerHandler(spawner);
            container.Bind<PlayerHandler>().To(handler);
        }
    }
}