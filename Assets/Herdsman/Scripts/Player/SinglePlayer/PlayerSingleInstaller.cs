using Adic.Container;
using Common.Dependecies.Abstract;
using Common.GameEntities.Abstract;
using Common.GameEntities.Spawner;
using Player.Entity;
using UnityEngine;

namespace Player.SinglePlayer
{
    [CreateAssetMenu(fileName = "PlayerSingleInstaller", menuName = "Installers/SinglePlayer/PlayerSingleInstaller")]
    public class PlayerSingleInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerViewPool poolPrefab;

        public override void Install(IInjectionContainer container)
        {
            var pool = Instantiate(poolPrefab);
            var factory = new GameEntityMediatorFactory<PlayerMediator, PlayerView>();
            var spawner = new GameEntitySpawner<PlayerMediator, PlayerView>(pool, factory);
            container.Bind<GameEntitySpawner<PlayerMediator, PlayerView>>().To(spawner);
            container.Bind<PlayerSingleHandler>().ToSingleton();
        }
    }
}